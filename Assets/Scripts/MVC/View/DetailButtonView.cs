using System;
using System.Collections.Generic;
using MVC.Controller.ControllerInterfaces;
using MVC.Model;
using MVC.Model.ModelInterfaces;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.View
{
    public class DetailButtonView : MonoBehaviour
    {
        [SerializeField] private Image imageSprite;
        [SerializeField] private Image backGround;
        [SerializeField] private TMP_Text neceseryCount;
        
        private List<IDisposable> _disposables = new List<IDisposable>();
        private IDetailsIncreaser _detailsIncreaser;
        private IAircraftDetailsStorage _aircraftDetailsStorage;
        private IDetailPerSecondModel _detailPerSecondModel;
        private DetailModel _detailModel;
        private AircraftModel _aircraftModel;

        public DetailModel DetailModel => _detailModel;

        public void Initialize(IAircraftDetailsStorage aircraftDetailsStorage, IDetailsIncreaser detailsIncreaser,
            DetailModel detailModel, AircraftModel aircraftModel, IDetailPerSecondModel detailPerSecondModel)
        {
            CachedFields(aircraftDetailsStorage, detailsIncreaser, detailModel, detailPerSecondModel, aircraftModel);
            SetStaticView(detailModel, aircraftModel);
            FillAmountImageSubscribe(detailModel, aircraftModel);
            AutoIncreaseDetailSubscribe(detailModel);
        }

        public void DetailButtonClick() => _detailsIncreaser.DetailButtonClick(_detailModel, _aircraftModel);

        private void AutoIncreaseDetailSubscribe(DetailModel detailModel)
        {
            Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    _aircraftDetailsStorage.DetailsCount[detailModel].Value +=
                        _detailPerSecondModel.DetailsPerSecondsDictionary[detailModel].Value * Time.deltaTime;
                })
                .AddTo(_disposables);
        }

        private void FillAmountImageSubscribe(DetailModel detailModel, AircraftModel aircraftModel)
        {
            _aircraftDetailsStorage.DetailsCount[detailModel].Subscribe(value =>
            {
                imageSprite.fillAmount = value / aircraftModel.CreationRecipe[detailModel]
                                         - (int)(value / aircraftModel.CreationRecipe[detailModel]);
            }).AddTo(_disposables);
        }

        private void SetStaticView(DetailModel detailModel, AircraftModel aircraftModel)
        {
            neceseryCount.text = aircraftModel.CreationRecipe[detailModel] + " нужно";
            imageSprite.sprite = _detailModel.Sprite;
            backGround.sprite = _detailModel.Sprite;
        }

        private void CachedFields(IAircraftDetailsStorage aircraftDetailsStorage, IDetailsIncreaser detailsIncreaser,
            DetailModel detailModel, IDetailPerSecondModel detailPerSecondModel, AircraftModel aircraftModel)
        {
            _aircraftModel = aircraftModel;
            _detailPerSecondModel = detailPerSecondModel;
            _aircraftDetailsStorage = aircraftDetailsStorage;
            _detailsIncreaser = detailsIncreaser;
            _detailModel = detailModel;
        }

        private void OnDestroy()
        {
            foreach (IDisposable disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
