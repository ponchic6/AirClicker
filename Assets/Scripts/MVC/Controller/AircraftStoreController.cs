using MVC.Model;

namespace MVC.Controller
{
    public class AircraftStoreController : IAircraftStoreController
    {
        private readonly IAircraftStorage _aircraftStorage;
        private readonly IAircraftsPriceListModel _aircraftsPriceListModel;
        private readonly IMoneyStorage _moneyStorage;

        public AircraftStoreController(IAircraftStorage aircraftStorage,
            IAircraftsPriceListModel aircraftsPriceListModel, IMoneyStorage moneyStorage)
        {
            _aircraftStorage = aircraftStorage;
            _aircraftsPriceListModel = aircraftsPriceListModel;
            _moneyStorage = moneyStorage;
        }
        
        public bool TrySellAircraft(AircraftModel aircraftModel)
        {
            if (_aircraftStorage.AircraftCountDictionary[aircraftModel].Value < 1) return false;

            _moneyStorage.Money.Value += _aircraftsPriceListModel.GetPrice(aircraftModel);
            _aircraftStorage.AircraftCountDictionary[aircraftModel].Value -= 1;
            return true;
        }
    }
}