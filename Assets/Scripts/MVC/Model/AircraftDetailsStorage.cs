using System.Collections.Generic;
using MVC.Model.ModelInterfaces;
using UniRx;

namespace MVC.Model
{
    public class AircraftDetailsStorage : IAircraftDetailsStorage
    {
        private readonly Dictionary<DetailModel, ReactiveProperty<float>> _detailsCountDictionary = new();
        private readonly Dictionary<AircraftModel, ReactiveProperty<float>> _aircraftCountDictionary = new();

        public Dictionary<DetailModel, ReactiveProperty<float>> DetailsCount => _detailsCountDictionary;
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftCountDictionary => _aircraftCountDictionary;
    }
}