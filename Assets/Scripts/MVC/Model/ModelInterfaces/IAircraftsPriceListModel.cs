using System.Collections.Generic;
using UniRx;

namespace MVC.Model
{
    public interface IAircraftsPriceListModel
    {
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftPriceDict { get; }
        public float GetPrice(AircraftModel aircraftModel);
        public void SetPrice(AircraftModel aircraftModel, float price);
    }
}