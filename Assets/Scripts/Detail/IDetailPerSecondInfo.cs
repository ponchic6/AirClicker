using System.Collections.Generic;
using UniRx;

namespace Detail
{
    public interface IDetailPerSecondInfo
    {
        public Dictionary<DetailModel, ReactiveProperty<float>> DetailsPerSeconds { get; }
    }
}