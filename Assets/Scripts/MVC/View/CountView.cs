using System;
using System.Collections.Generic;
using MVC.Model;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace MVC.View
{
    public class CountView : MonoBehaviour
    {   
        [SerializeField] private TMP_Text aircraftCount;
        [SerializeField] private TMP_Text chassisCount;
        [SerializeField] private TMP_Text engineCount;
        [SerializeField] private TMP_Text bodyCount;
        [SerializeField] private TMP_Text rocketCount;
        
        private List<IDisposable> _disposables = new List<IDisposable>();
        private IAircraftDetailsCountReadOnly _aircraftDetailsCountReadOnly;

        [Inject]
        public void Constructor(IAircraftDetailsCountReadOnly aircraftDetailsCountReadOnly)
        {
            _aircraftDetailsCountReadOnly = aircraftDetailsCountReadOnly;

            _aircraftDetailsCountReadOnly.AircraftCountReadOnly.Subscribe(value =>
            {
                aircraftCount.text = ((int)value).ToString();
            }).AddTo(_disposables);
            
            _aircraftDetailsCountReadOnly.ChassisCountReadOnly.Subscribe(value =>
            {
                chassisCount.text = ((int)value).ToString();
            }).AddTo(_disposables);
            
            _aircraftDetailsCountReadOnly.EngineCountReadOnly.Subscribe(value =>
            {
                engineCount.text = ((int)value).ToString();
            }).AddTo(_disposables);
            
            _aircraftDetailsCountReadOnly.AircraftBodyCountReadOnly.Subscribe(value =>
            {
                bodyCount.text = ((int)value).ToString();
            }).AddTo(_disposables);

            _aircraftDetailsCountReadOnly.RocketCountReadOnly.Subscribe(value =>
            {
                rocketCount.text = ((int)value).ToString();
            }).AddTo(_disposables);
        }

        private void OnDisable()
        {
            foreach (IDisposable disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
