using MVC.Controller;
using UnityEngine;
using Zenject;

namespace MVC.View
{
    public class MainCanvasClickerHandler : MonoBehaviour
    {
        private ICountFromClickController _countFromClickController;

        [Inject]
        public void Constructor(ICountFromClickController countFromClickController)
        {
            _countFromClickController = countFromClickController;
        }

        public void AircraftBuildingClick() => _countFromClickController.AircraftBuildingClick();
        public void ChassisButtonClick() => _countFromClickController.ChassisButtonClick();
        public void EngineButtonClick() => _countFromClickController.EngineButtonClick();
        public void BodyButtonClick() => _countFromClickController.BodyButtonClick();
        public void RocketButtonClick() => _countFromClickController.RocketButtonClick();
    }
}
