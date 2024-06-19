using MVC.Model;

namespace MVC.Controller
{
    public interface IAircraftStoreController
    {
        public void TrySellAircraft(AircraftModel aircraftModel);
    }
}