using System.Collections.Generic;
using Aircraft;
using Combo;
using Detail;
using MVC.View;
using Storages;
using UIViews;
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

        private readonly DiContainer _diContainer;
        private readonly IDetailsIncreaser _detailsIncreaser;
        private readonly IDetailsStorage _detailsStorage;
        private readonly IDetailPerSecondInfo _detailPerSecondInfo;
        private readonly IClickComboController _clickComboController;
        
        private GameObject _mainCanvas;

        public UIFactory(DiContainer diContainer, IDetailsIncreaser detailsIncreaser,
            IDetailsStorage detailsStorage, IDetailPerSecondInfo detailPerSecondInfo, 
            IClickComboController clickComboController)
        {
            _clickComboController = clickComboController;
            _detailsStorage = detailsStorage;
            _detailPerSecondInfo = detailPerSecondInfo;
            _detailsIncreaser = detailsIncreaser;
            _diContainer = diContainer;
        }

        public GameObject CreateMainClickerCanvas() => 
            _mainCanvas = _diContainer.InstantiatePrefabResource(MainClickerCanvasPath);

        public void CreateSelectionAircraftButton(Transform parent, AircraftModel aircraftModel)
        {
            GameObject selectionToggle = _diContainer.InstantiatePrefabResource(SelectionAircraftTogglePath, parent);
            selectionToggle.GetComponent<SelectionAircraftButtonView>().Initialize(aircraftModel);
        }

        public void CreateAircraftClickPanel(AircraftModel aircraftModel)
        {
            GameObject parent = _mainCanvas.GetComponentInChildren<GridLayoutGroup>().gameObject;

            DestroyPreviosDetailButtons(parent);
            InirializeNewDetailButtons(aircraftModel, parent);

            _clickComboController.SetAircraftModel(aircraftModel, _mainCanvas);
            
            _mainCanvas.GetComponentInChildren<AircraftMainIconView>().SetAircraftModel(aircraftModel);
            _mainCanvas.GetComponentInChildren<SellAircraftButtonView>().BindSellAircraftButton(aircraftModel);
            _mainCanvas.GetComponentInChildren<AutoBuildingAircraft>().StartAutoBuilding(aircraftModel);
        }

        public void CreateUpgradeDetailButton(Transform parent, DetailModel detailModel, ReactiveProperty<float> perSecond)
        {
            GameObject upgradeButton = _diContainer.InstantiatePrefabResource(DetailUpgradeButtonPath, parent);
            DetailUpgradeButtonView upgradeButtonView = upgradeButton.GetComponent<DetailUpgradeButtonView>();
            upgradeButtonView.Initialize(detailModel, detailModel.Sprite,
                _detailPerSecondInfo.DetailsPerSeconds[detailModel],
                _detailsStorage.DetailsCount[detailModel]);
        }

        private void InirializeNewDetailButtons(AircraftModel aircraftModel, GameObject parent)
        {
            foreach (KeyValuePair<DetailModel, int> keyValue in aircraftModel.CreationRecipe)
            {
                GameObject detailButton =
                    _diContainer.InstantiatePrefabResource(DetailButtonPath, parent.transform);

                detailButton.GetComponent<DetailButtonView>().Initialize(_detailsStorage, _detailsIncreaser,
                    keyValue.Key, aircraftModel, _detailPerSecondInfo);
            }
        }

        private void DestroyPreviosDetailButtons(GameObject parent)
        {
            foreach (Transform transform in parent.transform)
            {
                Object.Destroy(transform.gameObject);
            }
        }
    }
}