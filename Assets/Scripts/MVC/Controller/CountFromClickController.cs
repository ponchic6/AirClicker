using MVC.Model;
using UnityEngine;

namespace MVC.Controller
{
    public class CountFromClickController : ICountFromClickController
    {
        private readonly IAircraftDetailsCount _aircraftDetailsCount;

        public CountFromClickController(IAircraftDetailsCount aircraftDetailsCount)
        {
            _aircraftDetailsCount = aircraftDetailsCount;
        }

        public void AircraftBuildingClick()
        {
            if (DetailsEnoughForAircraft())
            {
                _aircraftDetailsCount.AircraftCount.Value++;
            }
        }

        public void ChassisButtonClick()
        {
            _aircraftDetailsCount.ChassisCount.Value++;
        }

        public void EngineButtonClick()
        {
            _aircraftDetailsCount.EngineCount.Value++;
        }

        public void BodyButtonClick()
        {
            _aircraftDetailsCount.AircraftBodyCount.Value++;
        }

        public void RocketButtonClick()
        {
            _aircraftDetailsCount.RocketCount.Value++;
        }

        private bool DetailsEnoughForAircraft()
        {
            return _aircraftDetailsCount.ChassisCountReadOnly.Value >= 1 &&
                   _aircraftDetailsCount.EngineCountReadOnly.Value >= 1 &&
                   _aircraftDetailsCount.AircraftBodyCountReadOnly.Value >= 1 &&
                   _aircraftDetailsCount.RocketCountReadOnly.Value >= 1;
        }
    }
}