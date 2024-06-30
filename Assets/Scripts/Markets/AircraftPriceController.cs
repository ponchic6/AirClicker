using System;
using System.Collections.Generic;
using Aircraft;
using Markets.MarketInterfaces;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Markets
{
    public class AircraftPriceController : IAircraftPriceController
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private IAircraftsPriceList _aircraftsPriceList;
        private float _cachedBasePrice;
        private AircraftModel _cashedAirModel;

        public AircraftPriceController(IAircraftsPriceList aircraftsPriceList)
        {
            _aircraftsPriceList = aircraftsPriceList;
        }
        
        public void StartDynamicPriceChange(AircraftModel aircraftModel)
        {
            if (_cashedAirModel != null)
            {
                _aircraftsPriceList.SetPrice(_cashedAirModel, _cachedBasePrice);
            }
            
            DisposeAll();

            _cachedBasePrice = _aircraftsPriceList.GetPrice(aircraftModel);

            Observable.Timer(TimeSpan.FromSeconds(0.6f)).Repeat().Subscribe(_ =>
            {
                float price = _cachedBasePrice +
                              Mathf.Sin(Time.time * 0.1f * Mathf.PI) * _cachedBasePrice + Random.value * _cachedBasePrice; 
                _aircraftsPriceList.SetPrice(aircraftModel, price);
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