using System;
using System.Collections.Generic;
using MVC.Controller;
using MVC.Model;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.View
{
    public class DetailButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text countText;
        [SerializeField] private TMP_Text reciepCount;
        [SerializeField] private Image imageSprite;
        
        private List<IDisposable> _disposables = new List<IDisposable>();
        private IDetailsIncreaser _detailsIncreaser;
        private IAircraftDetailsStorage _aircraftDetailsStorage;
        private IDetailPerSecondModel _detailPerSecondModel;
        private DetailModel _detailModel;

        public void Initialize(IAircraftDetailsStorage aircraftDetailsStorage, IDetailsIncreaser detailsIncreaser,
            DetailModel detailModel, AircraftModel aircraftModel, IDetailPerSecondModel detailPerSecondModel)
        {
            _detailPerSecondModel = detailPerSecondModel;
            _aircraftDetailsStorage = aircraftDetailsStorage;
            _detailsIncreaser = detailsIncreaser;
            _detailModel = detailModel;
            reciepCount.text = aircraftModel.CreationRecipeDictionary[detailModel].ToString();
            imageSprite.sprite = _detailModel.Sprite;

            _aircraftDetailsStorage.DetailsCountDictionary[detailModel].Subscribe(value =>
            {
                countText.text = ((int)value).ToString();
                imageSprite.fillAmount = value - (int)value;
            }).AddTo(_disposables);
            
            Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    _aircraftDetailsStorage.DetailsCountDictionary[detailModel].Value +=
                        _detailPerSecondModel.DetailsPerSecondsDictionary[detailModel].Value * Time.deltaTime;
                })
                .AddTo(_disposables);
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
