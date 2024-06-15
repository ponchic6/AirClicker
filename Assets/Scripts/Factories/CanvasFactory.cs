using Zenject;

namespace Factories
{
    public class CanvasFactory : ICanvasFactory
    {
        private const string MainClickerCanvasPath = "UI/ClickerCanvas";
        
        private DiContainer _diContainer;

        public CanvasFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public void CreateMainClickerCanvas()
        {
            _diContainer.InstantiatePrefabResource(MainClickerCanvasPath);
        }
    }
}