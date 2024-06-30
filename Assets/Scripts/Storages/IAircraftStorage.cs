using System.Collections.Generic;
using Aircraft;
using UniRx;

namespace Storages
{
    public interface IAircraftStorage
    {
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftCount { get; }
        public List<AircraftModel> AircraftList { get; }
    }
}