using System;
using MVC.Controller;
using MVC.Controller.ControllerInterfaces;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVC.View
{
    public class ComboSliderView : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        private IClickComboController _clickComboController;

        [Inject]
        public void Constructor(IClickComboController clickComboController)
        {
            _clickComboController = clickComboController;
        }

        private void Start()
        {
            _clickComboController.ComboSliderValue.Subscribe(value =>
            {
                slider.value = value;
            });
        }
    }
}
