using System.Collections.Generic;
using System.Linq;
using Aircraft;
using Detail;
using Factories;
using Markets.MarketInterfaces;
using StaticData;
using Storages;
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
        private IDetailsStorage _detailsStorage;
        private IDetailPerSecondInfo _detailPerSecondInfo;
        private IUpgradePriceList _upgradePriceList;
        private IAircraftsPriceList _aircraftsPriceList;
        private AircraftModelsList _aircraftModelsList;
        private IAircraftUnblockingPrices _aircraftUnblockingPrices;

        [Inject]
        public void Constructor(IUIFactory iuiFactory, IAircraftStorage aircraftStorage,
            IDetailsStorage detailsStorage, AircraftModelsList aircraftModelsList,
            IDetailPerSecondInfo detailPerSecondInfo, IUpgradePriceList upgradePriceList,
            IAircraftsPriceList aircraftsPriceList, IAircraftUnblockingPrices aircraftUnblockingPrices)
        {
            _aircraftUnblockingPrices = aircraftUnblockingPrices;
            _aircraftsPriceList = aircraftsPriceList;
            _upgradePriceList = upgradePriceList;
            _detailPerSecondInfo = detailPerSecondInfo;
            _aircraftModelsList = aircraftModelsList;
            _detailsStorage = detailsStorage;
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
            _aircraftsPriceList.AircraftPriceDict[aircraftModel] = new ReactiveProperty<float>();
            _aircraftsPriceList.AircraftPriceDict[aircraftModel].Value = aircraftModelSo.BasePrice;
            _aircraftUnblockingPrices.UnblockingPricesDict[aircraftModel] = aircraftModelSo.UnblockingPrice;
        }

        private AircraftModel InitializeAircraft(AircraftModelInitialConfig aircraftModelInitialConfig)
        {
            Dictionary<DetailModel, int> dictionaryReciep = new Dictionary<DetailModel, int>();

            foreach (AircraftItem item in aircraftModelInitialConfig.AircraftItemsContainer.AircraftItem)
            {
                DetailModel detailModel = _detailsStorage.DetailsCount.First(pair =>
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

            _detailsStorage.DetailsCount[detailModel] = new ReactiveProperty<float>();

            _upgradePriceList.PricesUpgradeModelDictionary[detailModel] = new ReactiveProperty<float>();
            _upgradePriceList.PricesUpgradeModelDictionary[detailModel].Value 
                = aircraftItem.DetailModel.initialUpgradePrice;
                        
            _detailPerSecondInfo.DetailsPerSeconds[detailModel] = new ReactiveProperty<float>();
        }

        private bool HasDictionaryDetailWithId(AircraftItem aircraftItem)
        {
            return _detailsStorage.DetailsCount.Keys.Any(detail => detail.Id == aircraftItem.DetailModel.id);
        }
    }
}
