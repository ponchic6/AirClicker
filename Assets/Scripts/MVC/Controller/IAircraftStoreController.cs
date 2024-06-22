using MVC.Model;

namespace MVC.Controller
{
    public interface IAircraftStoreController
    {
        public bool TrySellAircraft(AircraftModel aircraftModel);
    }
}