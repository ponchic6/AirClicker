using System;
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
        private GameObject _mainCanvas;
        private List<IDisposable> _disposables = new List<IDisposable>();
        private IDetailPerSecondModel _detailPerSecondModel;

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
            
            Dispose();
            _disposables.Clear();
            
            DeleteOldClickerPanel(detailsScrollRect);
            
            foreach (KeyValuePair<DetailModel, int> keyValue in aircraftModel.CreationRecipeDictionary)
            {
                CreateDetailButtonView(detailsScrollRect, keyValue);
                SubscribeOnDetailPerSecond(keyValue);
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

        private void SubscribeOnDetailPerSecond(KeyValuePair<DetailModel, int> keyValue)
        {
            Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    _aircraftDetailsStorage.DetailsCountDictionary[keyValue.Key].Value +=
                        _detailPerSecondModel.DetailsPerSecondsDictionary[keyValue.Key].Value * Time.deltaTime;
                })
                .AddTo(_disposables);
        }

        private void CreateDetailButtonView(GameObject detailsScrollRect, KeyValuePair<DetailModel, int> keyValue)
        {
            GameObject detailButton = 
                _diContainer.InstantiatePrefabResource(DetailButtonPath, detailsScrollRect.transform);

            detailButton.GetComponent<DetailButtonView>().DetailName.text = keyValue.Key.Id;
            detailButton.GetComponent<DetailButtonView>().Initialize(_aircraftDetailsStorage, _detailsIncreaser, keyValue.Key);
        }

        private void Dispose()
        {
            foreach (IDisposable disposable in _disposables)
            {
                disposable.Dispose();
            }
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