using System.Collections.Generic;
using Aircraft;
using Markets.MarketInterfaces;
using UniRx;

namespace Markets
{
    public class AircraftsPriceList : IAircraftsPriceList
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