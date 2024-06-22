using MVC.Model;
using UnityEngine.UI;

namespace MVC.Controller
{
    public interface IAircraftUnblockingController
    {
        public bool TryUnblockAircraft(AircraftModel aircraftModel, Button button, Button unblockingButton);
    }
}