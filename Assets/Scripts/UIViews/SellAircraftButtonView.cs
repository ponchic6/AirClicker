using System;
using System.Collections.Generic;
using Aircraft;
using Markets.MarketInterfaces;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UIViews
{
    public class SellAircraftButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text price;
        [SerializeField] private Button button;
        private IAircraftsPriceList _aircraftsPriceList;
        private IList<IDisposable> _disposables = new List<IDisposable>();
        private IAircraftStoreController _aircraftStoreController;
        private IAircraftPriceController _aircraftPriceController;

        [Inject]
        public void Constructor(IAircraftsPriceList aircraftsPriceList,
            IAircraftStoreController aircraftStoreController, IAircraftPriceController aircraftPriceController)
        {
            _aircraftPriceController = aircraftPriceController;
            _aircraftStoreController = aircraftStoreController;
            _aircraftsPriceList = aircraftsPriceList;
        }
        
        public void BindSellAircraftButton(AircraftModel aircraftModel)
        {   
            DisposeAll();
            button.onClick.RemoveAllListeners();

            _aircraftPriceController.StartDynamicPriceChange(aircraftModel);
                
            _aircraftsPriceList
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
