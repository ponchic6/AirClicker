using System.Collections.Generic;
using UniRx;

namespace MVC.Model
{
    public interface IAircraftsPriceListModel
    {
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftPriceDict { get; }
    }
}