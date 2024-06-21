using Factories;
using MVC.Controller;
using MVC.Model;
using StaticData;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private AircraftModelsList aircraftModelsList;
        
        public override void InstallBindings()
        {
            RegisterUnblockingPrices();
            RegisterMoneyStorage();
            RegisterUblockingController();
            RegisterAircraftsPriceList();
            RegisterAircraftPriceListController();
            RegisterUpgradePriceModel();
            RegisterDetailPerSecond();
            RegisterUpgradeStore();
            RegisterAircraftStaticData();
            RegisterAircraftDetailsStorage();
            RegisterAircraftStorage();
            RegisterAircraftStoreController();
            RegisterDetailsIncreaser();
            RegisterCanvasFactory();
        }

        private void RegisterAircraftPriceListController()
        {
            IAircraftPriceListController aircraftPriceListController =
                Container.Instantiate<AircraftPriceListController>();
            Container.Bind<IAircraftPriceListController>().FromInstance(aircraftPriceListController).AsSingle();
        }

        private void RegisterUnblockingPrices()
        {
            IAircraftUnblockingPrices aircraftUnblockingPrices = Container.Instantiate<AircraftUnblockingPrices>();
            Container.Bind<IAircraftUnblockingPrices>().FromInstance(aircraftUnblockingPrices).AsSingle();
        }

        private void RegisterUblockingController()
        {
            IAircraftUnblockingController aircraftUnblockingController = Container.Instantiate<AircraftUnblockingController>();
            Container.Bind<IAircraftUnblockingController>().FromInstance(aircraftUnblockingController).AsSingle();
        }

        private void RegisterAircraftStoreController()
        {
            IAircraftStoreController aircraftStoreController = Container.Instantiate<AircraftStoreController>();
            Container.Bind<IAircraftStoreController>().FromInstance(aircraftStoreController).AsSingle();
        }

        private void RegisterAircraftsPriceList()
        {
            IAircraftsPriceListModel aircraftsPriceListModel = Container.Instantiate<AircraftsPriceListModel>();
            Container.Bind<IAircraftsPriceListModel>().FromInstance(aircraftsPriceListModel).AsSingle();
        }

        private void RegisterMoneyStorage()
        {
            IMoneyStorage moneyStorage = Container.Instantiate<MoneyStorage>();
            Container.Bind<IMoneyStorage>().FromInstance(moneyStorage).AsSingle();
        }

        private void RegisterUpgradeStore()
        {
            IDetailUpgradeStore upgradeStore = Container.Instantiate<DetailUpgradeStore>();
            Container.Bind<IDetailUpgradeStore>().FromInstance(upgradeStore).AsSingle();
        }

        private void RegisterUpgradePriceModel()
        {
            IUpgradePriceModel upgradePriceModel = Container.Instantiate<UpgradePriceModel>();
            Container.Bind<IUpgradePriceModel>().FromInstance(upgradePriceModel).AsSingle();
        }

        private void RegisterDetailPerSecond()
        {
            IDetailPerSecondModel detailPerSecondModel = Container.Instantiate<DetailPerSecondModel>();
            Container.Bind<IDetailPerSecondModel>().FromInstance(detailPerSecondModel).AsSingle();
        }

        private void RegisterAircraftStaticData()
        {
            Container.Bind<AircraftModelsList>().FromInstance(aircraftModelsList).AsSingle();
        }

        private void RegisterAircraftDetailsStorage()
        {
            IAircraftDetailsStorage aircraftDetailsStorage = Container.Instantiate<AircraftDetailsStorage>();
            Container.Bind<IAircraftDetailsStorage>().FromInstance(aircraftDetailsStorage).AsSingle();
        }

        private void RegisterDetailsIncreaser()
        {
            IDetailsIncreaser detailsIncreaser = Container.Instantiate<DetailsIncreaser>();
            Container.Bind<IDetailsIncreaser>().FromInstance(detailsIncreaser).AsSingle();
        }

        private void RegisterAircraftStorage()
        {
            IAircraftStorage aircraftStorage = Container.Instantiate<AircraftStorage>();
            Container.Bind<IAircraftStorage>().FromInstance(aircraftStorage).AsSingle();
        }
        
        private void RegisterCanvasFactory()
        {
            IUIFactory iuiFactory = Container.Instantiate<UIFactory>();
            Container.Bind<IUIFactory>().FromInstance(iuiFactory).AsSingle();
        }
    }
}