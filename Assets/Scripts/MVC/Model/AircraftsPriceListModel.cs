using System.Collections.Generic;
using UniRx;

namespace MVC.Model
{
    public class AircraftsPriceListModel : IAircraftsPriceListModel
    {
        private readonly Dictionary<AircraftModel, ReactiveProperty<float>> _aircraftPriceDict = new();
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftPriceDict => _aircraftPriceDict;
    }
}