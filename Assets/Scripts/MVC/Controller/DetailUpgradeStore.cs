using MVC.Controller.ControllerInterfaces;
using MVC.Model;
using MVC.Model.ModelInterfaces;

namespace MVC.Controller
{
    public class DetailUpgradeStore : IDetailUpgradeStore
    {
        private readonly IDetailPerSecondModel _detailPerSecondModel;
        private readonly IMoneyStorage _moneyStorage;
        private readonly IUpgradePriceModel _upgradePriceModel;

        public DetailUpgradeStore(IDetailPerSecondModel detailPerSecondModel, IMoneyStorage moneyStorage,
            IUpgradePriceModel upgradePriceModel)
        {
            _moneyStorage = moneyStorage;
            _upgradePriceModel = upgradePriceModel;
            _detailPerSecondModel = detailPerSecondModel;
        }
        
        public bool Upgrade(DetailModel detailModel)
        {   
            if (_moneyStorage.Money.Value < _upgradePriceModel.PricesUpgradeModelDictionary[detailModel].Value) return false;
            
            _moneyStorage.Money.Value -= _upgradePriceModel.PricesUpgradeModelDictionary[detailModel].Value;
            _detailPerSecondModel.DetailsPerSecondsDictionary[detailModel].Value += detailModel.UpgradeValue;
            _upgradePriceModel.PricesUpgradeModelDictionary[detailModel].Value *= 1.15f;
            return true;
        }
    }
}