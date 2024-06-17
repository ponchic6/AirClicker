using MVC.Model;

namespace MVC.Controller
{
    public interface IDetailsIncreaser
    {
        public void DetailButtonClick(DetailModel detailModel);
        public void CreationAircraftClick(AircraftModel aircraftModel);
    }
}