﻿using System.Collections.Generic;
using MVC.Model;
using UniRx;
using UnityEngine.UI;

namespace MVC.Controller
{
    public class AircraftUnblockingController : IAircraftUnblockingController
    {
        private readonly IMoneyStorage _moneyStorage;
        private readonly IAircraftUnblockingPrices _aircraftUnblockingPrices;

        public AircraftUnblockingController(IMoneyStorage moneyStorage,
            IAircraftUnblockingPrices aircraftUnblockingPrices)
        {
            _moneyStorage = moneyStorage;
            _aircraftUnblockingPrices = aircraftUnblockingPrices;
        }
        
        public bool TryUnblockAircraft(AircraftModel aircraftModel, Button button, Button unblockingButton)
        {
            if (_moneyStorage.Money.Value < _aircraftUnblockingPrices.UnblockingPricesDict[aircraftModel]) return false;

            foreach (KeyValuePair<DetailModel, int> keyValue  in aircraftModel.CreationRecipe)
            {
                keyValue.Key.Available = true;
            }
                        
            _moneyStorage.Money.Value -= _aircraftUnblockingPrices.UnblockingPricesDict[aircraftModel];
            button.interactable = true;
            unblockingButton.gameObject.SetActive(false);
            return true;
        }
    }
}