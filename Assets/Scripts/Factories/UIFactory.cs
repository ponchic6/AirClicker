using System.Collections.Generic;
using MVC.Controller;
using MVC.Model;
using MVC.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Factories
{
    public class UIFactory : IUIFactory
    {
        private const string MainClickerCanvasPath = "UI/ClickerCanvas";
        private const string SelectionAircraftTogglePath = "UI/SelectionAircraftToggle";
        private const string DetailButtonPath = "UI/DetailButton";

        private readonly IDetailsIncreaser _detailsIncreaser;
        private readonly IAircraftDetailsStorage _aircraftDetailsStorage;
        private readonly DiContainer _diContainer;
        private GameObject _mainCanvas;

        public UIFactory(DiContainer diContainer, IDetailsIncreaser detailsIncreaser,
            IAircraftDetailsStorage aircraftDetailsStorage)
        {
            _aircraftDetailsStorage = aircraftDetailsStorage;
            _detailsIncreaser = detailsIncreaser;
            _diContainer = diContainer;
        }

        public void CreateMainClickerCanvas()
        {
            _mainCanvas = _diContainer.InstantiatePrefabResource(MainClickerCanvasPath);
        }

        public GameObject CreateSelectionAircraftButton(Transform parent, AircraftModel aircraftModel)
        {
            GameObject selectionToggle = _diContainer.InstantiatePrefabResource(SelectionAircraftTogglePath, parent);
            selectionToggle.GetComponent<SelectionAircraftButtonView>().icon.sprite = aircraftModel.Sprite;
            selectionToggle.GetComponentInChildren<TMP_Text>().text = aircraftModel.Id.ToString();
            return selectionToggle;
        }

        public void CreateAircraftClickPanel(AircraftModel aircraftModel)
        {
            GameObject detailsScrollRect = _mainCanvas.GetComponentInChildren<ScrollRect>().gameObject;

            DeleteOldClickerPanel(detailsScrollRect);
            
            foreach (KeyValuePair<DetailModel, int> keyValue in aircraftModel.CreationRecipeDictionary)
            {
                GameObject detailButton = 
                    _diContainer.InstantiatePrefabResource(DetailButtonPath, detailsScrollRect.transform);

                detailButton.GetComponent<DetailButtonView>().DetailName.text = keyValue.Key.Id.ToString();
                detailButton.GetComponent<DetailButtonView>().Initialize(_aircraftDetailsStorage, _detailsIncreaser, keyValue.Key);
            }

            _mainCanvas.GetComponentInChildren<CreationAircraftButtonView>().SetAircraftModel(aircraftModel);
        }

        private void DeleteOldClickerPanel(GameObject detailsScrollRect)
        {
            foreach (Transform transform in detailsScrollRect.transform)
            {
                Object.Destroy(transform.gameObject);
            }
        }
    }
}