using MVC.Model;
using UnityEngine;

namespace Factories
{
    public interface IUIFactory
    {
        public void CreateMainClickerCanvas();
        public GameObject CreateSelectionAircraftButton(Transform parent, AircraftModel aircraftModel);
        public void CreateAircraftClickPanel(AircraftModel aircraftModel);
    }
}