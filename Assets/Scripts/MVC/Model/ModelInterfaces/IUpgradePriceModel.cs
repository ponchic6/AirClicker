using System.Collections.Generic;
using UniRx;

namespace MVC.Model.ModelInterfaces
{
    public interface IUpgradePriceModel
    {
        public Dictionary<DetailModel, ReactiveProperty<float>> PricesUpgradeModelDictionary { get;}
    }
}