using System;
using System.Collections.Generic;
using MVC.Controller.ControllerInterfaces;
using MVC.Model;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVC.View
{
    public class SellAircraftButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text price;
        [SerializeField] private Button button;
        private IAircraftsPriceListModel _aircraftsPriceListModel;
        private IList<IDisposable> _disposables = new List<IDisposable>();
        private IAircraftStoreController _aircraftStoreController;
        private IAircraftPriceController _aircraftPriceController;

        [Inject]
        public void Constructor(IAircraftsPriceListModel aircraftsPriceListModel,
            IAircraftStoreController aircraftStoreController, IAircraftPriceController aircraftPriceController)
        {
            _aircraftPriceController = aircraftPriceController;
            _aircraftStoreController = aircraftStoreController;
            _aircraftsPriceListModel = aircraftsPriceListModel;
        }
        
        public void BindSellAircraftButton(AircraftModel aircraftModel)
        {   
            DisposeAll();
            button.onClick.RemoveAllListeners();

            _aircraftPriceController.StartDynamicPriceChange(aircraftModel);
                
            _aircraftsPriceListModel
                .AircraftPriceDict[aircraftModel]
                .Subscribe(value =>
                {
                    price.text = decimal.Round((decimal)value, 2) + " $";
                })
                .AddTo(_disposables);
            
            button.onClick.AddListener(() =>
            {
                _aircraftStoreController.TrySellAircraft(aircraftModel);
            });
        }

        private void DisposeAll()
        {
            foreach (IDisposable disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
