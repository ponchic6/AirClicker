using System.Collections.Generic;
using UniRx;

namespace MVC.Model
{
    public interface IUpgradePriceModel
    {
        public Dictionary<DetailModel, ReactiveProperty<float>> PricesUpgradeModelDictionary { get;}
    }
}