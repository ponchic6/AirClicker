using System;
using System.Collections.Generic;
using MVC.Controller;
using MVC.Model;
using UniRx;
using UnityEngine;
using Zenject;

namespace MVC.View
{
    public class AutoBuildingAircraft : MonoBehaviour
    {
        private IDetailsIncreaser _detailsIncreaser;
        private List<IDisposable> _disposables = new List<IDisposable>();

        [Inject]
        public void Constructor(IDetailsIncreaser detailsIncreaser)
        {
            _detailsIncreaser = detailsIncreaser;
        }
        
        public void StartAutoBuilding(AircraftModel aircraftModel)
        {
            foreach (IDisposable disposable in _disposables)
            {
                disposable.Dispose();
            }
            
            Observable.EveryUpdate().Subscribe(_ =>
            {
                _detailsIncreaser.TryCreateAircraft(aircraftModel);
            }).AddTo(_disposables);
        }
    }
}
