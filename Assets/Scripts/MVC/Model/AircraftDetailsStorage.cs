using System.Collections.Generic;
using Infrastructure;
using UniRx;

namespace MVC.Model
{
    public class AircraftDetailsStorage : IAircraftDetailsStorage
    {
        private Dictionary<DetailModel, ReactiveProperty<float>> _detailsCountDictionary = new();
        private Dictionary<AircraftModel, ReactiveProperty<float>> _aircraftCountDictionary { get; } = new();

        public Dictionary<DetailModel, ReactiveProperty<float>> DetailsCount => _detailsCountDictionary;
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftCountDictionary => _aircraftCountDictionary;
    }
}