using Aircraft;
using UnityEngine.UI;

namespace Markets.MarketInterfaces
{
    public interface IAircraftUnblockingController
    {
        public bool TryUnblockAircraft(AircraftModel aircraftModel, Button button, Button unblockingButton);
    }
}