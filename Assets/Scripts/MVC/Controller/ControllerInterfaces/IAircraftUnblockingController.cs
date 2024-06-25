using MVC.Model;
using UnityEngine.UI;

namespace MVC.Controller.ControllerInterfaces
{
    public interface IAircraftUnblockingController
    {
        public bool TryUnblockAircraft(AircraftModel aircraftModel, Button button, Button unblockingButton);
    }
}