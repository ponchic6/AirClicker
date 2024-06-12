using MVC.Model;

namespace MVC.Controller
{
    public class DetailsCountController
    {
        private readonly AircraftDetailsCount _aircraftDetailsCount;

        public DetailsCountController(AircraftDetailsCount aircraftDetailsCount)
        {
            _aircraftDetailsCount = aircraftDetailsCount;
        }
    }
}