using MVC.Model;
using UniRx;
using UnityEngine;

namespace MVC.Controller
{
    public class AutoIncreaseController : IAutoIncreaseController
    {
        private readonly IAutoIncreaseModel _autoIncreaseModel;
        private readonly IAircraftDetailsCount _aircraftDetailsCount;

        public AutoIncreaseController(IAutoIncreaseModel autoIncreaseModel, IAircraftDetailsCount aircraftDetailsCount)
        {
            _autoIncreaseModel = autoIncreaseModel;
            _aircraftDetailsCount = aircraftDetailsCount;
            
            Observable.EveryUpdate().Subscribe(_ => UpdateDetailCount());
        }
        
        private void UpdateDetailCount()
        {
            _aircraftDetailsCount.ChassisCount.Value += _autoIncreaseModel.ChassisPerSecond * Time.deltaTime;
            _aircraftDetailsCount.EngineCount.Value += _autoIncreaseModel.EnginePerSecond * Time.deltaTime;
            _aircraftDetailsCount.AircraftBodyCount.Value += _autoIncreaseModel.BodyPerSecond * Time.deltaTime;
            _aircraftDetailsCount.RocketCount.Value += _autoIncreaseModel.RocketPerSecond * Time.deltaTime;
        }
    }
}