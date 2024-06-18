using System.Collections.Generic;
using UniRx;

namespace MVC.Model
{
    public class DetailPerSecondModel : IDetailPerSecondModel
    {
        private Dictionary<DetailModel, ReactiveProperty<float>> _detailsPerSecondsDictionary = new();

        public Dictionary<DetailModel, ReactiveProperty<float>> DetailsPerSecondsDictionary =>
            _detailsPerSecondsDictionary;
    }
}