using MVC.Model;

namespace MVC.Controller.ControllerInterfaces
{
    public interface IAircraftStoreController
    {
        public bool TrySellAircraft(AircraftModel aircraftModel);
    }
}