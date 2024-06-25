using System.Collections.Generic;
using UniRx;

namespace MVC.Model.ModelInterfaces
{
    public interface IAircraftDetailsStorage
    {
        public Dictionary<DetailModel, ReactiveProperty<float>> DetailsCount { get; }
    }
}