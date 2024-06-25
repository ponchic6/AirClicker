using Factories;
using MVC.Controller.ControllerInterfaces;
using MVC.Model;
using MVC.Model.ModelInterfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVC.View
{
    public class SelectionAircraftButtonView : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Button button;
        [SerializeField] private Button unblockingButton;

        private IAircraftUnblockingController _aircraftUnblockingController;
        private IAircraftUnblockingPrices _aircraftUnblockingPrices;
        private IUIFactory _uiFactory;

        [Inject]
        public void Constructor(IUIFactory uiFactory, IAircraftUnblockingController aircraftUnblockingController,
            IAircraftUnblockingPrices aircraftUnblockingPrices)
        {
            _aircraftUnblockingPrices = aircraftUnblockingPrices;
            _aircraftUnblockingController = aircraftUnblockingController;
            _uiFactory = uiFactory;
        }
        
        public void Initialize(AircraftModel aircraftModel)
        {
            icon.sprite = aircraftModel.Sprite;
            button.onClick.AddListener(() =>
            {
                _uiFactory.CreateAircraftClickPanel(aircraftModel);
            });
            
            button.interactable = aircraftModel.IsAvailable;

            unblockingButton.GetComponentInChildren<TMP_Text>().text =
                _aircraftUnblockingPrices.UnblockingPricesDict[aircraftModel] + " $";
            
            unblockingButton.onClick.AddListener(() =>
            {
                _aircraftUnblockingController.TryUnblockAircraft(aircraftModel, button, unblockingButton);
            });
            
            unblockingButton.gameObject.SetActive(!aircraftModel.IsAvailable);
        }
    }
}