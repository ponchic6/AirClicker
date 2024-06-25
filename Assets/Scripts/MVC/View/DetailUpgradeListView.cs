using System;
using System.Collections.Generic;
using Factories;
using MVC.Model;
using MVC.Model.ModelInterfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace MVC.View
{
    public class DetailUpgradeListView : MonoBehaviour
    {
        private IDetailPerSecondModel _detailPerSecondModel;
        private IAircraftDetailsStorage _aircraftDetailsStorage;
        private IUIFactory _uiFactory;

        [Inject]
        public void Constructor(IAircraftDetailsStorage aircraftDetailsStorage, IDetailPerSecondModel detailPerSecondModel,
            IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _aircraftDetailsStorage = aircraftDetailsStorage;
            _detailPerSecondModel = detailPerSecondModel;
        }
        
        private void OnEnable()
        {
            RerenderViewUpgradeList();
        }

        private void RerenderViewUpgradeList()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.transform.gameObject);
            }

            foreach (KeyValuePair<DetailModel, ReactiveProperty<float>> keyValue in _aircraftDetailsStorage
                         .DetailsCount)
            {
                if (!keyValue.Key.Available) return;
                
                _uiFactory.CreateUpgradeDetailButton(transform, keyValue.Key,
                    _detailPerSecondModel.DetailsPerSecondsDictionary[keyValue.Key]);
            }
        }
    }
}
