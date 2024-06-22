using MVC.Model;
using UnityEngine.UI;

namespace MVC.Controller
{
    public class AircraftUnblockingController : IAircraftUnblockingController
    {
        private readonly IMoneyStorage _moneyStorage;
        private readonly IAircraftUnblockingPrices _aircraftUnblockingPrices;

        public AircraftUnblockingController(IMoneyStorage moneyStorage, IAircraftUnblockingPrices aircraftUnblockingPrices)
        {
            _moneyStorage = moneyStorage;
            _aircraftUnblockingPrices = aircraftUnblockingPrices;
        }
        
        public bool TryUnblockAircraft(AircraftModel aircraftModel, Button button, Button unblockingButton)
        {
            if (_moneyStorage.Money.Value < _aircraftUnblockingPrices.UnblockingPricesDict[aircraftModel]) return false;

            _moneyStorage.Money.Value -= _aircraftUnblockingPrices.UnblockingPricesDict[aircraftModel];
            button.interactable = true;
            unblockingButton.gameObject.SetActive(false);
            return true;
        }
    }
}