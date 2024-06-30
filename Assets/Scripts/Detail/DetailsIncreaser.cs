using System.Collections.Generic;
using Aircraft;
using Combo;
using Storages;
using UnityEngine;

namespace Detail
{
    public class DetailsIncreaser : IDetailsIncreaser
    {
        private readonly IDetailsStorage _detailsStorage;
        private readonly IAircraftStorage _aircraftStorage;
        private IClickComboController _clickComboController;

        public DetailsIncreaser(IDetailsStorage detailsStorage, IAircraftStorage aircraftStorage,
            IClickComboController clickComboController)
        {
            _clickComboController = clickComboController;
            _aircraftStorage = aircraftStorage;
            _detailsStorage = detailsStorage;
        }
        
        public void DetailButtonClick(DetailModel detailModel, AircraftModel aircraftModel)
        {
            _detailsStorage.DetailsCount[detailModel].Value +=
                aircraftModel.CreationRecipe[detailModel] * Random.value * 0.1f * (1 + _clickComboController.ComboClickMultiplier);
        }

        public void TryCreateAircraft(AircraftModel aircraftModel)
        {
            foreach (KeyValuePair<DetailModel, int> keyValue in aircraftModel.CreationRecipe)
            {
                if (_detailsStorage.DetailsCount[keyValue.Key].Value < keyValue.Value) return;
            }

            _aircraftStorage.AircraftCount[aircraftModel].Value++;

            foreach (KeyValuePair<DetailModel, int> keyValue in aircraftModel.CreationRecipe)
            {
                _detailsStorage.DetailsCount[keyValue.Key].Value -= keyValue.Value;
            }
        }
    }
}