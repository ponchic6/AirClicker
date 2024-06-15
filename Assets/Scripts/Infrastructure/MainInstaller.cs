using Factories;
using MVC.Controller;
using MVC.Model;
using Zenject;

namespace Infrastructure
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterAircraftDetailsCount();
            RegisterClickController();
            RegisterAutoIncreaseModel();
            RegisterAutoIncreaseController();
            RegisterCanvasFactory();
        }

        private void RegisterAutoIncreaseController()
        {
            IAutoIncreaseController autoIncreaseController = Container.Instantiate<AutoIncreaseController>();
            Container.Bind<IAutoIncreaseController>().FromInstance(autoIncreaseController).AsSingle();
        }

        private void RegisterAutoIncreaseModel()
        {
            IAutoIncreaseModel autoIncreaseModel = Container.Instantiate<AutoIncreaseModel>();
            Container.Bind<IAutoIncreaseModel>().FromInstance(autoIncreaseModel).AsSingle();
        }

        private void RegisterAircraftDetailsCount()
        {
            AircraftDetailsCount aircraftDetailsCount = Container.Instantiate<AircraftDetailsCount>();
            Container.Bind<IAircraftDetailsCount>().FromInstance(aircraftDetailsCount).AsSingle();
            Container.Bind<IAircraftDetailsCountReadOnly>().FromInstance(aircraftDetailsCount).AsSingle();
        }

        private void RegisterClickController()
        {
            CountFromClickController countFromClickController = Container.Instantiate<CountFromClickController>();
            Container.Bind<ICountFromClickController>().FromInstance(countFromClickController).AsSingle();
        }

        private void RegisterCanvasFactory()
        {
            ICanvasFactory canvasFactory = Container.Instantiate<CanvasFactory>();
            Container.Bind<ICanvasFactory>().FromInstance(canvasFactory).AsSingle();
        }
    }
}