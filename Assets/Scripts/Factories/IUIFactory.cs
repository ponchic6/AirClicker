using MVC.Model;
using UniRx;
using UnityEngine;

namespace Factories
{
    public interface IUIFactory
    {
        public void CreateMainClickerCanvas();
        public GameObject CreateSelectionAircraftButton(Transform parent, AircraftModel aircraftModel);
        public void CreateAircraftClickPanel(AircraftModel aircraftModel);
        public void CreateUpgradeDetailButton(Transform parent, DetailModel detailModel,
            ReactiveProperty<float> perSecond);
    }
}