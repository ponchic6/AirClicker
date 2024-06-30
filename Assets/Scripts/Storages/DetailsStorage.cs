using System.Collections.Generic;
using Aircraft;
using Detail;
using UniRx;

namespace Storages
{
    public class DetailsStorage : IDetailsStorage
    {
        private readonly Dictionary<DetailModel, ReactiveProperty<float>> _detailsCountDictionary = new();
        private readonly Dictionary<AircraftModel, ReactiveProperty<float>> _aircraftCountDictionary = new();

        public Dictionary<DetailModel, ReactiveProperty<float>> DetailsCount => _detailsCountDictionary;
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftCountDictionary => _aircraftCountDictionary;
    }
}