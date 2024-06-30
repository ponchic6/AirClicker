using Combo;
using Detail;
using Factories;
using Markets;
using Markets.MarketInterfaces;
using StaticData;
using Storages;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private AircraftModelsList aircraftModelsList;
        [SerializeField] private ComboStaticData comboStaticData;
        
        public override void InstallBindings()
        {
            RegisterComboStaticData();
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
            RegisterClickComboController();
            RegisterDetailsIncreaser();
            RegisterCanvasFactory();
        }

        private void RegisterComboStaticData()
        {
            Container.Bind<ComboStaticData>().FromInstance(comboStaticData).AsSingle();
        }

        private void RegisterClickComboController()
        {
            IClickComboController clickComboController = Container.Instantiate<ClickComboController>();
            Container.Bind<IClickComboController>().FromInstance(clickComboController).AsSingle();
        }

        private void RegisterAircraftPriceListController()
        {
            IAircraftPriceController aircraftPriceController =
                Container.Instantiate<AircraftPriceController>();
            Container.Bind<IAircraftPriceController>().FromInstance(aircraftPriceController).AsSingle();
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
            IAircraftsPriceList aircraftsPriceList = Container.Instantiate<AircraftsPriceList>();
            Container.Bind<IAircraftsPriceList>().FromInstance(aircraftsPriceList).AsSingle();
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
            IUpgradePriceList upgradePriceList = Container.Instantiate<UpgradePriceList>();
            Container.Bind<IUpgradePriceList>().FromInstance(upgradePriceList).AsSingle();
        }

        private void RegisterDetailPerSecond()
        {
            IDetailPerSecondInfo detailPerSecondInfo = Container.Instantiate<DetailPerSecondInfo>();
            Container.Bind<IDetailPerSecondInfo>().FromInstance(detailPerSecondInfo).AsSingle();
        }

        private void RegisterAircraftStaticData()
        {
            Container.Bind<AircraftModelsList>().FromInstance(aircraftModelsList).AsSingle();
        }

        private void RegisterAircraftDetailsStorage()
        {
            IDetailsStorage detailsStorage = Container.Instantiate<DetailsStorage>();
            Container.Bind<IDetailsStorage>().FromInstance(detailsStorage).AsSingle();
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