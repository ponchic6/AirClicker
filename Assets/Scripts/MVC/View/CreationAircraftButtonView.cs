using System;
using System.Collections.Generic;
using MVC.Controller;
using MVC.Model;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVC.View
{
    public class CreationAircraftButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text countView;
        [SerializeField] private Image aircraftIcon;
        private List<IDisposable> _disposables = new List<IDisposable>();
        private AircraftModel _aircraftModel;
        private IAircraftStorage _aircraftStorage;
        private IDetailsIncreaser _detailsIncreaser;

        [Inject]
        public void Constructor(IAircraftStorage aircraftStorage, IDetailsIncreaser detailsIncreaser)
        {
            _detailsIncreaser = detailsIncreaser;
            _aircraftStorage = aircraftStorage;
        }

        public void CreationAircraftClick()
        {
            _detailsIncreaser.CreationAircraftClick(_aircraftModel);
        }

        public void SetAircraftModel(AircraftModel aircraftModel)
        {
            Dispose();
        
            _aircraftModel = aircraftModel;
            aircraftIcon.sprite = aircraftModel.Sprite;
            _aircraftStorage.AircraftCountDictionary[_aircraftModel].Subscribe(value =>
            {
                countView.text = ((int)value).ToString();
            }).AddTo(_disposables);
        }

        private void Dispose()
        {   
            foreach (IDisposable disposable in _disposables)
            {
                disposable.Dispose();
            }
            
            _disposables.Clear();
        }
    }
}
