using Aircraft;
using MVC.View;
using UIViews;
using UniRx;
using UnityEngine;

namespace Combo
{
    public interface IClickComboController
    {
        public void SetAircraftModel(AircraftModel aircraftModel, GameObject mainCanvas);
        public void TryToContinueCombo(DetailButtonView detailButtonView);
        public ReactiveProperty<float> ComboSliderValue { get; }
        public float ComboClickMultiplier { get; }
    }
}