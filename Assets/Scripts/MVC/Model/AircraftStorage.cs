using System.Collections.Generic;
using Infrastructure;
using UniRx;

namespace MVC.Model
{
    public class AircraftStorage : IAircraftStorage
    {
        private Dictionary<AircraftModel, ReactiveProperty<float>> _aircraftCountDictionary { get; } = new();
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftCountDictionary => _aircraftCountDictionary;
    }
}