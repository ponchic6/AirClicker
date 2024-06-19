using System.Collections.Generic;
using UniRx;

namespace MVC.Model
{
    public class UpgradePriceModel : IUpgradePriceModel
    {
        private Dictionary<DetailModel, ReactiveProperty<float>> _pricesUpgradeModelDictionary = new();

        public Dictionary<DetailModel, ReactiveProperty<float>> PricesUpgradeModelDictionary =>
            _pricesUpgradeModelDictionary;
    }
}