using MVC.Model;

namespace MVC.Controller.ControllerInterfaces
{
    public interface IAircraftPriceController
    {
        public void StartDynamicPriceChange(AircraftModel aircraftModel);
    }
}