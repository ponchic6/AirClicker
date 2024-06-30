using Detail;
using Markets.MarketInterfaces;
using Storages;

namespace Markets
{
    public class DetailUpgradeStore : IDetailUpgradeStore
    {
        private readonly IDetailPerSecondInfo _detailPerSecondInfo;
        private readonly IMoneyStorage _moneyStorage;
        private readonly IUpgradePriceList _upgradePriceList;

        public DetailUpgradeStore(IDetailPerSecondInfo detailPerSecondInfo, IMoneyStorage moneyStorage,
            IUpgradePriceList upgradePriceList)
        {
            _moneyStorage = moneyStorage;
            _upgradePriceList = upgradePriceList;
            _detailPerSecondInfo = detailPerSecondInfo;
        }
        
        public bool Upgrade(DetailModel detailModel)
        {   
            if (_moneyStorage.Money.Value < _upgradePriceList.PricesUpgradeModelDictionary[detailModel].Value) return false;
            
            _moneyStorage.Money.Value -= _upgradePriceList.PricesUpgradeModelDictionary[detailModel].Value;
            _detailPerSecondInfo.DetailsPerSeconds[detailModel].Value += detailModel.UpgradeValue;
            _upgradePriceList.PricesUpgradeModelDictionary[detailModel].Value *= 1.15f;
            return true;
        }
    }
}