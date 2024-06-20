using System;
using System.Collections.Generic;
using MVC.Controller;
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

        [Inject]
        public void Constructor(IAircraftsPriceListModel aircraftsPriceListModel,
            IAircraftStoreController aircraftStoreController)
        {
            _aircraftStoreController = aircraftStoreController;
            _aircraftsPriceListModel = aircraftsPriceListModel;
        }
        
        public void BindSellAircraftButton(AircraftModel aircraftModel)
        {   
            button.onClick.RemoveAllListeners();
            
            _aircraftsPriceListModel
                .AircraftPriceDict[aircraftModel]
                .Subscribe(value =>
                {
                    price.text = value + " $";
                })
                .AddTo(_disposables);
            
            button.onClick.AddListener(() =>
            {
                _aircraftStoreController.TrySellAircraft(aircraftModel);
            });
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
