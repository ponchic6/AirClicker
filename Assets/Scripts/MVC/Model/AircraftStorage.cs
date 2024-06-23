using System.Collections.Generic;
using Infrastructure;
using UniRx;

namespace MVC.Model
{
    public class AircraftStorage : IAircraftStorage
    {
        private readonly Dictionary<AircraftModel, ReactiveProperty<float>> _aircraftCountDictionary = new();
        private readonly List<AircraftModel> _aircraftList = new();
        
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftCount => _aircraftCountDictionary;
        public List<AircraftModel> AircraftList => _aircraftList;
    }
}