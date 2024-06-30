using System.Collections.Generic;
using UniRx;

namespace Detail
{
    public class DetailPerSecondInfo : IDetailPerSecondInfo
    {
        private readonly Dictionary<DetailModel, ReactiveProperty<float>> _detailsPerSeconds = new();

        public Dictionary<DetailModel, ReactiveProperty<float>> DetailsPerSeconds =>
            _detailsPerSeconds;
    }
}