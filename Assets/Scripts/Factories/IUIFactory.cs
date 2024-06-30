using Aircraft;
using Detail;
using UniRx;
using UnityEngine;

namespace Factories
{
    public interface IUIFactory
    {
        public GameObject CreateMainClickerCanvas();
        public void CreateSelectionAircraftButton(Transform parent, AircraftModel aircraftModel);
        public void CreateAircraftClickPanel(AircraftModel aircraftModel);
        public void CreateUpgradeDetailButton(Transform parent, DetailModel detailModel,
            ReactiveProperty<float> perSecond);
    }
}