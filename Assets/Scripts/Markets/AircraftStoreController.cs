using Aircraft;
using Markets.MarketInterfaces;
using Storages;

namespace Markets
{
    public class AircraftStoreController : IAircraftStoreController
    {
        private readonly IAircraftStorage _aircraftStorage;
        private readonly IAircraftsPriceList _aircraftsPriceList;
        private readonly IMoneyStorage _moneyStorage;

        public AircraftStoreController(IAircraftStorage aircraftStorage,
            IAircraftsPriceList aircraftsPriceList, IMoneyStorage moneyStorage)
        {
            _aircraftStorage = aircraftStorage;
            _aircraftsPriceList = aircraftsPriceList;
            _moneyStorage = moneyStorage;
        }
        
        public bool TrySellAircraft(AircraftModel aircraftModel)
        {
            if (_aircraftStorage.AircraftCount[aircraftModel].Value < 1) return false;

            _moneyStorage.Money.Value += _aircraftsPriceList.GetPrice(aircraftModel);
            _aircraftStorage.AircraftCount[aircraftModel].Value -= 1;
            return true;
        }
    }
}