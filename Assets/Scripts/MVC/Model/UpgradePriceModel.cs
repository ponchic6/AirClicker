using System.Collections.Generic;
using MVC.Model.ModelInterfaces;
using UniRx;

namespace MVC.Model
{
    public class UpgradePriceModel : IUpgradePriceModel
    {
        private readonly Dictionary<DetailModel, ReactiveProperty<float>> _pricesUpgradeModelDictionary = new();

        public Dictionary<DetailModel, ReactiveProperty<float>> PricesUpgradeModelDictionary =>
            _pricesUpgradeModelDictionary;
    }
}