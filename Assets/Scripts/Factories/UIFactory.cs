﻿using System;
using System.Collections.Generic;
using MVC.Controller;
using MVC.Model;
using MVC.View;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Object = UnityEngine.Object;

namespace Factories
{
    public class UIFactory : IUIFactory
    {
        private const string MainClickerCanvasPath = "UI/ClickerCanvas";
        private const string SelectionAircraftTogglePath = "UI/SelectionAircraftToggle";
        private const string DetailButtonPath = "UI/DetailButton";
        private const string DetailUpgradeButtonPath = "UI/ImproveDetailButton";

        private readonly IDetailsIncreaser _detailsIncreaser;
        private readonly IAircraftDetailsStorage _aircraftDetailsStorage;
        private readonly DiContainer _diContainer;
        private readonly IDetailPerSecondModel _detailPerSecondModel;
        private GameObject _mainCanvas;

        public UIFactory(DiContainer diContainer, IDetailsIncreaser detailsIncreaser,
            IAircraftDetailsStorage aircraftDetailsStorage, IDetailPerSecondModel detailPerSecondModel)
        {
            _aircraftDetailsStorage = aircraftDetailsStorage;
            _detailPerSecondModel = detailPerSecondModel;
            _detailsIncreaser = detailsIncreaser;
            _diContainer = diContainer;
        }

        public void CreateMainClickerCanvas()
        {
            _mainCanvas = _diContainer.InstantiatePrefabResource(MainClickerCanvasPath);
        }

        public void CreateSelectionAircraftButton(Transform parent, AircraftModel aircraftModel)
        {
            GameObject selectionToggle = _diContainer.InstantiatePrefabResource(SelectionAircraftTogglePath, parent);
            selectionToggle.GetComponent<SelectionAircraftButtonView>().Initialize(aircraftModel);
        }

        public void CreateAircraftClickPanel(AircraftModel aircraftModel)
        {
            GameObject detailsScrollRect = _mainCanvas.GetComponentInChildren<ScrollRect>().gameObject;

            foreach (Transform transform in detailsScrollRect.transform)
            {
                Object.Destroy(transform.gameObject);
            }

            foreach (KeyValuePair<DetailModel, int> keyValue in aircraftModel.CreationRecipeDictionary)
            {
                GameObject detailButton = 
                    _diContainer.InstantiatePrefabResource(DetailButtonPath, detailsScrollRect.transform);
            
                detailButton.GetComponent<DetailButtonView>().Initialize(_aircraftDetailsStorage, _detailsIncreaser,
                    keyValue.Key, aircraftModel, _detailPerSecondModel);
            }
            
            _mainCanvas.GetComponentInChildren<CreationAircraftButtonView>().SetAircraftModel(aircraftModel);
            _mainCanvas.GetComponentInChildren<SellAircraftButtonView>().BindSellAircraftButton(aircraftModel);
        }

        public void CreateUpgradeDetailButton(Transform parent, DetailModel detailModel, ReactiveProperty<float> perSecond)
        {
            GameObject upgradeButton = _diContainer.InstantiatePrefabResource(DetailUpgradeButtonPath, parent);
            DetailUpgradeButtonView upgradeButtonView = upgradeButton.GetComponent<DetailUpgradeButtonView>();
            upgradeButtonView.Initialize(detailModel, detailModel.Sprite,
                _detailPerSecondModel.DetailsPerSecondsDictionary[detailModel],
                _aircraftDetailsStorage.DetailsCountDictionary[detailModel]);
        }
    }
}