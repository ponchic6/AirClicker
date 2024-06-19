using MVC.Model;

namespace MVC.Controller
{
    public class DetailUpgradeStore : IDetailUpgradeStore
    {
        private readonly IDetailPerSecondModel _detailPerSecondModel;
        private readonly IMoneyStorage _moneyStorage;
        private readonly IUpgradePriceModel _upgradePriceModel;

        public DetailUpgradeStore(IDetailPerSecondModel detailPerSecondModel, IMoneyStorage moneyStorage, IUpgradePriceModel upgradePriceModel)
        {
            _moneyStorage = moneyStorage;
            _upgradePriceModel = upgradePriceModel;
            _detailPerSecondModel = detailPerSecondModel;
        }
        
        public void Upgrade(DetailModel detailModel)
        {
            _moneyStorage.Money.Value -= _upgradePriceModel.PricesUpgradeModelDictionary[detailModel].Value;
            _detailPerSecondModel.DetailsPerSecondsDictionary[detailModel].Value++;
        }
    }
}