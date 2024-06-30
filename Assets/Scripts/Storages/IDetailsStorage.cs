using System.Collections.Generic;
using Detail;
using UniRx;

namespace Storages
{
    public interface IDetailsStorage
    {
        public Dictionary<DetailModel, ReactiveProperty<float>> DetailsCount { get; }
    }
}