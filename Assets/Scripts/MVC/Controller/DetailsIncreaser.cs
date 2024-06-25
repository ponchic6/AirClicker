using System.Collections.Generic;
using MVC.Controller.ControllerInterfaces;
using MVC.Model;
using MVC.Model.ModelInterfaces;
using UnityEngine;

namespace MVC.Controller
{
    public class DetailsIncreaser : IDetailsIncreaser
    {
        private readonly IAircraftDetailsStorage _aircraftDetailsStorage;
        private readonly IAircraftStorage _aircraftStorage;
        private IClickComboController _clickComboController;

        public DetailsIncreaser(IAircraftDetailsStorage aircraftDetailsStorage, IAircraftStorage aircraftStorage,
            IClickComboController clickComboController)
        {
            _clickComboController = clickComboController;
            _aircraftStorage = aircraftStorage;
            _aircraftDetailsStorage = aircraftDetailsStorage;
        }
        
        public void DetailButtonClick(DetailModel detailModel, AircraftModel aircraftModel)
        {
            _aircraftDetailsStorage.DetailsCount[detailModel].Value +=
                aircraftModel.CreationRecipe[detailModel] * Random.value * 0.1f * (1 + _clickComboController.ComboClickMultiplier);
        }

        public void TryCreateAircraft(AircraftModel aircraftModel)
        {
            foreach (KeyValuePair<DetailModel, int> keyValue in aircraftModel.CreationRecipe)
            {
                if (_aircraftDetailsStorage.DetailsCount[keyValue.Key].Value < keyValue.Value) return;
            }

            _aircraftStorage.AircraftCount[aircraftModel].Value++;

            foreach (KeyValuePair<DetailModel, int> keyValue in aircraftModel.CreationRecipe)
            {
                _aircraftDetailsStorage.DetailsCount[keyValue.Key].Value -= keyValue.Value;
            }
        }
    }
}