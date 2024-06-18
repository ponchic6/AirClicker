using System.Collections.Generic;
using UniRx;

namespace MVC.Model
{
    public interface IDetailPerSecondModel
    {
        public Dictionary<DetailModel, ReactiveProperty<float>> DetailsPerSecondsDictionary { get; }
    }
}