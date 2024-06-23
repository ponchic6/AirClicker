using System;
using MVC.Controller;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace MVC.View
{
    public class ComboOutlineView : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private DetailButtonView detailButtonView;
        [SerializeField] private Image image;
        
        private IClickComboController _clickComboController;

        [Inject]
        public void Constructor(IClickComboController clickComboController)
        {
            _clickComboController = clickComboController;
        }

        private void Start()
        {
            button.onClick.AddListener(() =>
            {
                _clickComboController.TryToContinueCombo(detailButtonView);
            });
        }

        public void ShowComboOutline()
        {
            image.gameObject.SetActive(true);
        }

        public void HideComboOutline()
        {
            image.gameObject.SetActive(false);
        }
    }
}
