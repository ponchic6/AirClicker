using System.Collections.Generic;
using System.Linq;
using Factories;
using MVC.Model;
using MVC.Model.ModelInterfaces;
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
            Application.targetFrameRate = 60;
            
            SceneManager.LoadScene("MainScene");

            foreach (AircraftModelInitialConfig aircraftModelSo in _aircraftModelsList.AircraftModels)
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
                InitializeAirctaftModels(aircraftModel, aircraftModelSo);
            } 
            
            GameObject mainCanvas = _uiFactory.CreateMainClickerCanvas();
            mainCanvas.GetComponentInChildren<Camera>().gameObject.transform.SetParent(null);
        }

        private void InitializeAirctaftModels(AircraftModel aircraftModel, AircraftModelInitialConfig aircraftModelSo)
        {
            _aircraftStorage.AircraftCount[aircraftModel] = new ReactiveProperty<float>();
            _aircraftStorage.AircraftList.Add(aircraftModel);
            _aircraftsPriceListModel.AircraftPriceDict[aircraftModel] = new ReactiveProperty<float>();
            _aircraftsPriceListModel.AircraftPriceDict[aircraftModel].Value = aircraftModelSo.BasePrice;
            _aircraftUnblockingPrices.UnblockingPricesDict[aircraftModel] = aircraftModelSo.UnblockingPrice;
        }

        private AircraftModel InitializeAircraft(AircraftModelInitialConfig aircraftModelInitialConfig)
        {
            Dictionary<DetailModel, int> dictionaryReciep = new Dictionary<DetailModel, int>();

            foreach (AircraftItem item in aircraftModelInitialConfig.AircraftItemsContainer.AircraftItem)
            {
                DetailModel detailModel = _aircraftDetailsStorage.DetailsCount.First(pair =>
                    pair.Key.Id == item.DetailModel.id).Key;
                dictionaryReciep[detailModel] = item.Count;

                detailModel.Available = aircraftModelInitialConfig.AvailableOnStart;
            }

            AircraftModel aircraftModel = new AircraftModel(dictionaryReciep, aircraftModelInitialConfig.Id,
                aircraftModelInitialConfig.Sprite, aircraftModelInitialConfig.AvailableOnStart);
            return aircraftModel;
        }

        private void InitializeDetailModel(AircraftItem aircraftItem)
        {
            DetailModel detailModel = new DetailModel(aircraftItem.DetailModel.id,
                aircraftItem.DetailModel.sprite, aircraftItem.DetailModel.upgradeValue);

            _aircraftDetailsStorage.DetailsCount[detailModel] = new ReactiveProperty<float>();

            _upgradePriceModel.PricesUpgradeModelDictionary[detailModel] = new ReactiveProperty<float>();
            _upgradePriceModel.PricesUpgradeModelDictionary[detailModel].Value 
                = aircraftItem.DetailModel.initialUpgradePrice;
                        
            _detailPerSecondModel.DetailsPerSecondsDictionary[detailModel] = new ReactiveProperty<float>();
        }

        private bool HasDictionaryDetailWithId(AircraftItem aircraftItem)
        {
            return _aircraftDetailsStorage.DetailsCount.Keys.Any(detail => detail.Id == aircraftItem.DetailModel.id);
        }
    }
}
