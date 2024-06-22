using System.Collections.Generic;
using UniRx;

namespace MVC.Model
{
    public class AircraftsPriceListModel : IAircraftsPriceListModel
    {
        private readonly Dictionary<AircraftModel, ReactiveProperty<float>> _aircraftPriceDict = new();
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftPriceDict => _aircraftPriceDict;
        
        public float GetPrice(AircraftModel aircraftModel)
        {
            return _aircraftPriceDict[aircraftModel].Value;
        }

        public void SetPrice(AircraftModel aircraftModel, float price)
        {
            _aircraftPriceDict[aircraftModel].Value = price;
        }
    }
}