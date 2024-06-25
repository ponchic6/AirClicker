using Factories;
using MVC.Model;
using MVC.Model.ModelInterfaces;
using UnityEngine;
using Zenject;

namespace MVC.View
{
    public class SelectionAircraftView : MonoBehaviour
    {
        private IAircraftStorage _aircraftStorage;
        private IUIFactory _uiFactory;

        [Inject]
        public void Constructor(IAircraftStorage aircraftStorage, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _aircraftStorage = aircraftStorage;
        }

        private void Start()
        {
            foreach (AircraftModel aircraftModel in _aircraftStorage.AircraftList)
            {
                _uiFactory.CreateSelectionAircraftButton(transform, aircraftModel);
            }
        }
    }
}
