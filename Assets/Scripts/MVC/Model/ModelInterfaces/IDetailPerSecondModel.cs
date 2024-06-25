using System.Collections.Generic;
using UniRx;

namespace MVC.Model.ModelInterfaces
{
    public interface IDetailPerSecondModel
    {
        public Dictionary<DetailModel, ReactiveProperty<float>> DetailsPerSecondsDictionary { get; }
    }
}