using System;
using System.Collections.Generic;
using Aircraft;
using Detail;
using UniRx;
using UnityEngine;
using Zenject;

namespace UIViews
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
            DisposeAll();

            Observable.EveryUpdate().Subscribe(_ =>
            {
                _detailsIncreaser.TryCreateAircraft(aircraftModel);
            }).AddTo(_disposables);
        }

        private void DisposeAll()
        {
            foreach (IDisposable disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
