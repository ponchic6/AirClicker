using System.Linq;
using MVC.Model;
using MVC.View;
using StaticData;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace MVC.Controller
{
    public class ClickComboController : IClickComboController
    {
        private Random _random = new Random();
        private AircraftModel _aircraftModel;
        private GameObject _mainCanvas;
        private DetailModel _detailModel;
        private ComboStaticData _comboStaticData;
        private float _comboClickMultiplier;
        
        public ReactiveProperty<float> ComboSliderValue { get; }
        public float ComboClickMultiplier => _comboClickMultiplier;

        public ClickComboController(ComboStaticData comboStaticData)
        {
            _comboStaticData = comboStaticData;
            ComboSliderValue = new ReactiveProperty<float>();

            SubscribeOnDecreaseComboMultiplier();
        }

        public void SetAircraftModel(AircraftModel aircraftModel, GameObject mainCanvas)
        {
            _aircraftModel = aircraftModel;
            _mainCanvas = mainCanvas;

            SetNextComboDetail();
        }

        public void TryToContinueCombo(DetailButtonView detailButtonView)
        {
            if (detailButtonView.DetailModel == _detailModel)
            {
                _comboClickMultiplier += _comboStaticData.increaseForOneClick;
                SetNextComboDetail();
            }

            else
            {
                _comboClickMultiplier = 0f;
                SetNextComboDetail();
            }
        }

        private void SubscribeOnDecreaseComboMultiplier()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                float decreaseSpeed = _comboStaticData
                    .decreaseDependence
                    .Evaluate(_comboClickMultiplier / _comboStaticData.maxBoost) * _comboStaticData.decreaseMultiplier;
                
                _comboClickMultiplier -= decreaseSpeed * Time.deltaTime;

                if (_comboClickMultiplier < 0)
                    _comboClickMultiplier = 0f;

                ComboSliderValue.Value = _comboClickMultiplier / _comboStaticData.maxBoost;
            });
        }

        private void SetNextComboDetail()
        {
            if (_detailModel != null)
            {
                foreach (Transform detailButtonTransform in _mainCanvas.GetComponentInChildren<GridLayoutGroup>().transform)
                {
                    if (_detailModel == detailButtonTransform.GetComponent<DetailButtonView>().DetailModel)
                    {
                        detailButtonTransform.GetComponent<ComboOutlineView>().HideComboOutline();
                        break;
                    }
                }
            }
            
            int count = _aircraftModel.CreationRecipe.Count;
            _detailModel = _aircraftModel.CreationRecipe.ElementAt(_random.Next(count)).Key;

            Transform transform = _mainCanvas.GetComponentInChildren<GridLayoutGroup>().transform;

            foreach (Transform detailButtonTransform in transform)
            {
                if (_detailModel == detailButtonTransform.GetComponent<DetailButtonView>().DetailModel)
                {
                    detailButtonTransform.GetComponent<ComboOutlineView>().ShowComboOutline();
                    return;
                }
            }
        }
    }
}