using System.Collections.Generic;
using Aircraft;
using UniRx;

namespace Markets.MarketInterfaces
{
    public interface IAircraftsPriceList
    {
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftPriceDict { get; }
        public float GetPrice(AircraftModel aircraftModel);
        public void SetPrice(AircraftModel aircraftModel, float price);
    }
}