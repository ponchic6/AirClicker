using System.Collections.Generic;
using Detail;
using Markets.MarketInterfaces;
using UniRx;

namespace Markets
{
    public class UpgradePriceList : IUpgradePriceList
    {
        private readonly Dictionary<DetailModel, ReactiveProperty<float>> _pricesUpgradeModelDictionary = new();

        public Dictionary<DetailModel, ReactiveProperty<float>> PricesUpgradeModelDictionary =>
            _pricesUpgradeModelDictionary;
    }
}