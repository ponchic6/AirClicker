using System.Collections.Generic;
using UniRx;

namespace MVC.Model.ModelInterfaces
{
    public interface IAircraftStorage
    {
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftCount { get; }
        public List<AircraftModel> AircraftList { get; }
    }
}