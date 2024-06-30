using System.Collections.Generic;
using Detail;
using UniRx;

namespace Markets.MarketInterfaces
{
    public interface IUpgradePriceList
    {
        public Dictionary<DetailModel, ReactiveProperty<float>> PricesUpgradeModelDictionary { get;}
    }
}