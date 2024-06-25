using System.Collections.Generic;
using MVC.Model.ModelInterfaces;
using UniRx;

namespace MVC.Model
{
    public class DetailPerSecondModel : IDetailPerSecondModel
    {
        private readonly Dictionary<DetailModel, ReactiveProperty<float>> _detailsPerSecondsDictionary = new();

        public Dictionary<DetailModel, ReactiveProperty<float>> DetailsPerSecondsDictionary =>
            _detailsPerSecondsDictionary;
    }
}