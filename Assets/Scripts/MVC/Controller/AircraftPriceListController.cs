using System;
using System.Collections.Generic;
using MVC.Model;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MVC.Controller
{
    public class AircraftPriceListController : IAircraftPriceListController
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private IAircraftsPriceListModel _aircraftsPriceListModel;
        private float _cachedBasePrice;
        private AircraftModel _cashedAirModel;

        public AircraftPriceListController(IAircraftsPriceListModel aircraftsPriceListModel)
        {
            _aircraftsPriceListModel = aircraftsPriceListModel;
        }
        
        public void StartDynamicPriceChange(AircraftModel aircraftModel)
        {
            if (_cashedAirModel != null)
            {
                _aircraftsPriceListModel.SetPrice(_cashedAirModel, _cachedBasePrice);
            }
            
            DisposeAll();

            _cachedBasePrice = _aircraftsPriceListModel.GetPrice(aircraftModel);

            Observable.Timer(TimeSpan.FromSeconds(0.6f)).Repeat().Subscribe(_ =>
            {   
                _aircraftsPriceListModel.SetPrice(aircraftModel,
                    _cachedBasePrice + Mathf.Sin(Time.time * 0.1f * Mathf.PI) * _cachedBasePrice * Random.value * 2);
            }).AddTo(_disposables);
            
            _cashedAirModel = aircraftModel;
        }

        private void DisposeAll()
        {
            foreach (IDisposable disposable in _disposables)
            {
                disposable.Dispose();
            }

            _disposables.Clear();
        }
    }
}