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
                foreach (AircraftSerializableItem aircraftSerializableItem in aircraftModelSo.DetailsDictionary
                             .AircraftSerializableItem)
                {
                    if (!HasDictionaryDetailWithId(aircraftSerializableItem))
                    {
                        InitializeDetailModel(aircraftSerializableItem);
                    }
                }

                Dictionary<DetailModel, int> dictionaryReciep = new Dictionary<DetailModel, int>();
                
                foreach (AircraftSerializableItem item in aircraftModelSo.DetailsDictionary.AircraftSerializableItem)
                {
                    DetailModel detailModel = _aircraftDetailsStorage.DetailsCountDictionary.FirstOrDefault(pair =>
                        pair.Key.Id == item.DetailModel.ID).Key;
                    dictionaryReciep[detailModel] = item.Count;
                }

                AircraftModel aircraftModel = new AircraftModel(dictionaryReciep, aircraftModelSo.Id,
                    aircraftModelSo.Sprite, aircraftModelSo.AvailableOnStart);
                
                _aircraftStorage.AircraftCountDictionary[aircraftModel] = new ReactiveProperty<float>();
                _aircraftsPriceListModel.AircraftPriceDict[aircraftModel] = new ReactiveProperty<float>();
                _aircraftsPriceListModel.AircraftPriceDict[aircraftModel].Value = aircraftModelSo.InitialPrice;
                _aircraftUnblockingPrices.UnblockingPricesDict[aircraftModel] = aircraftModelSo.UnblockingPrice;
            } 
            
            _uiFactory.CreateMainClickerCanvas();
        }

        private void InitializeDetailModel(AircraftSerializableItem aircraftSerializableItem)
        {
            DetailModel detailModel = new DetailModel(aircraftSerializableItem.DetailModel.ID,
                aircraftSerializableItem.DetailModel.Sprite);
                        
            _aircraftDetailsStorage.DetailsCountDictionary[detailModel] = new ReactiveProperty<float>();
                        
            _upgradePriceModel.PricesUpgradeModelDictionary[detailModel] = new ReactiveProperty<float>();
            _upgradePriceModel.PricesUpgradeModelDictionary[detailModel].Value 
                = aircraftSerializableItem.DetailModel.InitialUpgradePrice;
                        
            _detailPerSecondModel.DetailsPerSecondsDictionary[detailModel] = new ReactiveProperty<float>();
            _detailPerSecondModel.DetailsPerSecondsDictionary[detailModel].Value = 0.1f;
        }

        private bool HasDictionaryDetailWithId(AircraftSerializableItem aircraftSerializableItem)
        {
            return _aircraftDetailsStorage.DetailsCountDictionary.Keys.Any(detail => detail.Id == aircraftSerializableItem.DetailModel.ID);
        }
    }
}
