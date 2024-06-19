using System.Collections.Generic;
using MVC.Model;

namespace MVC.Controller
{
    public class DetailsIncreaser : IDetailsIncreaser
    {
        private readonly IAircraftDetailsStorage _aircraftDetailsStorage;
        private readonly IAircraftStorage _aircraftStorage;

        public DetailsIncreaser(IAircraftDetailsStorage aircraftDetailsStorage, IAircraftStorage aircraftStorage)
        {
            _aircraftStorage = aircraftStorage;
            _aircraftDetailsStorage = aircraftDetailsStorage;
        }

        public void CreationAircraftClick(AircraftModel aircraftModel)
        {
            foreach (KeyValuePair<DetailModel, int> keyValue in aircraftModel.CreationRecipeDictionary)
            {
                if (_aircraftDetailsStorage.DetailsCountDictionary[keyValue.Key].Value < keyValue.Value) return;
            }

            _aircraftStorage.AircraftCountDictionary[aircraftModel].Value++;
            
            foreach (KeyValuePair<DetailModel, int> keyValue in aircraftModel.CreationRecipeDictionary)
            {
                _aircraftDetailsStorage.DetailsCountDictionary[keyValue.Key].Value -= keyValue.Value;
            }
        }

        public void DetailButtonClick(DetailModel detailModel)
        {
            _aircraftDetailsStorage.DetailsCountDictionary[detailModel].Value += 0.3f;
        }
    }
}