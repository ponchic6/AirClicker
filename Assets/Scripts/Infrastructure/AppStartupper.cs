using System.Collections.Generic;
using System.Linq;
using Factories;
using MVC.Model;
using StaticData;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilites;
using Zenject;

namespace Infrastructure
{
    public class AppStartupper : MonoBehaviour
    {
        private IUIFactory _uiFactory;
        private IAircraftStorage _aircraftStorage;
        private IAircraftDetailsStorage _aircraftDetailsStorage;
        private IDetailPerSecondModel _detailPerSecondModel;
        private IUpgradePriceModel _upgradePriceModel;
        private IAircraftsPriceListModel _aircraftsPriceListModel;
        private AircraftModelsList _aircraftModelsList;
        private IAircraftUnblockingPrices _aircraftUnblockingPrices;

        [Inject]
        public void Constructor(IUIFactory iuiFactory, IAircraftStorage aircraftStorage,
            IAircraftDetailsStorage aircraftDetailsStorage, AircraftModelsList aircraftModelsList,
            IDetailPerSecondModel detailPerSecondModel, IUpgradePriceModel upgradePriceModel,
            IAircraftsPriceListModel aircraftsPriceListModel, IAircraftUnblockingPrices aircraftUnblockingPrices)
        {
            _aircraftUnblockingPrices = aircraftUnblockingPrices;
            _aircraftsPriceListModel = aircraftsPriceListModel;
            _upgradePriceModel = upgradePriceModel;
            _detailPerSecondModel = detailPerSecondModel;
            _aircraftModelsList = aircraftModelsList;
            _aircraftDetailsStorage = aircraftDetailsStorage;
            _aircraftStorage = aircraftStorage;
            _uiFactory = iuiFactory;
        }

        private void Start()
        {
            SceneManager.LoadScene("MainScene");

            foreach (AircraftModelSo aircraftModelSo in _aircraftModelsList.AircraftModels)
            {
                foreach (AircraftItem aircraftSerializableItem in aircraftModelSo.AircraftItemsContainer
                             .AircraftItem)
                {
                    if (!HasDictionaryDetailWithId(aircraftSerializableItem))
                    {
                        InitializeDetailModel(aircraftSerializableItem);
                    }
                }

                AircraftModel aircraftModel = InitializeAircraft(aircraftModelSo);

                _aircraftStorage.AircraftCount[aircraftModel] = new ReactiveProperty<float>();
                _aircraftStorage.AircraftList.Add(aircraftModel);
                _aircraftsPriceListModel.AircraftPriceDict[aircraftModel] = new ReactiveProperty<float>();
                _aircraftsPriceListModel.AircraftPriceDict[aircraftModel].Value = aircraftModelSo.InitialPrice;
                _aircraftUnblockingPrices.UnblockingPricesDict[aircraftModel] = aircraftModelSo.UnblockingPrice;
            } 
            
            GameObject mainCanvas = _uiFactory.CreateMainClickerCanvas();
            mainCanvas.GetComponentInChildren<Camera>().gameObject.transform.SetParent(null);
        }

        private AircraftModel InitializeAircraft(AircraftModelSo aircraftModelSo)
        {
            Dictionary<DetailModel, int> dictionaryReciep = new Dictionary<DetailModel, int>();

            foreach (AircraftItem item in aircraftModelSo.AircraftItemsContainer.AircraftItem)
            {
                DetailModel detailModel = _aircraftDetailsStorage.DetailsCount.First(pair =>
                    pair.Key.Id == item.DetailModel.ID).Key;
                dictionaryReciep[detailModel] = item.Count;

                detailModel.Available = aircraftModelSo.AvailableOnStart;
            }

            AircraftModel aircraftModel = new AircraftModel(dictionaryReciep, aircraftModelSo.Id,
                aircraftModelSo.Sprite, aircraftModelSo.AvailableOnStart);
            return aircraftModel;
        }

        private void InitializeDetailModel(AircraftItem aircraftItem)
        {
            DetailModel detailModel = new DetailModel(aircraftItem.DetailModel.ID,
                aircraftItem.DetailModel.Sprite, aircraftItem.DetailModel.UpgradeValue);

            _aircraftDetailsStorage.DetailsCount[detailModel] = new ReactiveProperty<float>();

            _upgradePriceModel.PricesUpgradeModelDictionary[detailModel] = new ReactiveProperty<float>();
            _upgradePriceModel.PricesUpgradeModelDictionary[detailModel].Value 
                = aircraftItem.DetailModel.InitialUpgradePrice;
                        
            _detailPerSecondModel.DetailsPerSecondsDictionary[detailModel] = new ReactiveProperty<float>();
        }

        private bool HasDictionaryDetailWithId(AircraftItem aircraftItem)
        {
            return _aircraftDetailsStorage.DetailsCount.Keys.Any(detail => detail.Id == aircraftItem.DetailModel.ID);
        }
    }
}
