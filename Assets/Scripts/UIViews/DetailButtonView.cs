using System;
using System.Collections.Generic;
using Aircraft;
using Detail;
using Storages;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UIViews
{
    public class DetailButtonView : MonoBehaviour
    {
        [SerializeField] private Image imageSprite;
        [SerializeField] private Image backGround;
        [SerializeField] private TMP_Text neceseryCount;
        
        private List<IDisposable> _disposables = new List<IDisposable>();
        private IDetailsIncreaser _detailsIncreaser;
        private IDetailsStorage _detailsStorage;
        private IDetailPerSecondInfo _detailPerSecondInfo;
        private DetailModel _detailModel;
        private AircraftModel _aircraftModel;

        public DetailModel DetailModel => _detailModel;

        public void Initialize(IDetailsStorage detailsStorage, IDetailsIncreaser detailsIncreaser,
            DetailModel detailModel, AircraftModel aircraftModel, IDetailPerSecondInfo detailPerSecondInfo)
        {
            CachedFields(detailsStorage, detailsIncreaser, detailModel, detailPerSecondInfo, aircraftModel);
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
                    _detailsStorage.DetailsCount[detailModel].Value +=
                        _detailPerSecondInfo.DetailsPerSeconds[detailModel].Value * Time.deltaTime;
                })
                .AddTo(_disposables);
        }

        private void FillAmountImageSubscribe(DetailModel detailModel, AircraftModel aircraftModel)
        {
            _detailsStorage.DetailsCount[detailModel].Subscribe(value =>
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

        private void CachedFields(IDetailsStorage detailsStorage, IDetailsIncreaser detailsIncreaser,
            DetailModel detailModel, IDetailPerSecondInfo detailPerSecondInfo, AircraftModel aircraftModel)
        {
            _aircraftModel = aircraftModel;
            _detailPerSecondInfo = detailPerSecondInfo;
            _detailsStorage = detailsStorage;
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
