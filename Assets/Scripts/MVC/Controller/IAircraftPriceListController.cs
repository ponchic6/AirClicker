using MVC.Model;

namespace MVC.Controller
{
    public interface IAircraftPriceListController
    {
        public void StartDynamicPriceChange(AircraftModel aircraftModel);
    }
}