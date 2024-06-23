﻿using MVC.Model;
using MVC.View;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.Controller
{
    public interface IClickComboController
    {
        public void SetAircraftModel(AircraftModel aircraftModel, GameObject mainCanvas);
        public void TryToContinueCombo(DetailButtonView detailButtonView);
        public ReactiveProperty<float> ComboSliderValue { get; }
        public float ComboClickMultiplier { get; }
    }
}