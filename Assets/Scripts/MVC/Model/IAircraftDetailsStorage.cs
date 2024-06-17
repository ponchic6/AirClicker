using System.Collections.Generic;
using UniRx;

namespace MVC.Model
{
    public interface IAircraftDetailsStorage
    {
        public Dictionary<DetailModel, ReactiveProperty<float>> DetailsCountDictionary { get; }
    }
}