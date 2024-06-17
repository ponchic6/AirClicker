using System;
using System.Collections.Generic;
using MVC.Controller;
using MVC.Model;
using TMPro;
using UniRx;
using UnityEngine;

namespace MVC.View
{
    public class DetailButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text countText;
        [SerializeField] private TMP_Text detailName;
        private List<IDisposable> _disposables = new List<IDisposable>();
        private IDetailsIncreaser _detailsIncreaser;
        private IAircraftDetailsStorage _aircraftDetailsStorage;
        private DetailModel _detailModel;

        public TMP_Text DetailName => detailName;
        
        public void Initialize(IAircraftDetailsStorage aircraftDetailsStorage, IDetailsIncreaser detailsIncreaser,
            DetailModel detailModel)
        {   
            _aircraftDetailsStorage = aircraftDetailsStorage;
            _detailsIncreaser = detailsIncreaser;
            _detailModel = detailModel;

            _aircraftDetailsStorage.DetailsCountDictionary[detailModel].Subscribe(value =>
            {
                countText.text = ((int)value).ToString();
            }).AddTo(_disposables);
        }

        public void DetailButtonClick() => _detailsIncreaser.DetailButtonClick(_detailModel);

        private void OnDestroy()
        {
            foreach (IDisposable disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
