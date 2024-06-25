using MVC.Model;

namespace MVC.Controller.ControllerInterfaces
{
    public interface IDetailsIncreaser
    {
        public void DetailButtonClick(DetailModel detailModel, AircraftModel aircraftModel);
        public void TryCreateAircraft(AircraftModel aircraftModel);
    }
}