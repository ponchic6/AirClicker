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
            RegisterAircraftStaticData();
            RegisterAircraftDetailsStorage();
            RegisterAircraftStorage();
            RegisterDetailsIncreaser();
            RegisterCanvasFactory();
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