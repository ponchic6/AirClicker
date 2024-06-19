using System.Collections.Generic;
using Factories;
using MVC.Model;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MVC.View
{
    public class SelectionAircraftView : MonoBehaviour
    {
        private IAircraftStorage _aircraftStorage;
        private IUIFactory _uiFactory;

        [Inject]
        public void Constructor(IAircraftStorage aircraftStorage, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _aircraftStorage = aircraftStorage;
        }

        private void Start()
        {
            foreach (KeyValuePair<AircraftModel, ReactiveProperty<float>> keyValue in _aircraftStorage.AircraftCountDictionary)
            {
                _uiFactory.CreateSelectionAircraftButton(transform, keyValue.Key);
            }        
        }
    }
}
