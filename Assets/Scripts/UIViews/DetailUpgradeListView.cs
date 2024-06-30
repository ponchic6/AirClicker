using System.Collections.Generic;
using Detail;
using Factories;
using Storages;
using UniRx;
using UnityEngine;
using Zenject;

namespace UIViews
{
    public class DetailUpgradeListView : MonoBehaviour
    {
        private IDetailPerSecondInfo _detailPerSecondInfo;
        private IDetailsStorage _detailsStorage;
        private IUIFactory _uiFactory;

        [Inject]
        public void Constructor(IDetailsStorage detailsStorage, IDetailPerSecondInfo detailPerSecondInfo,
            IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _detailsStorage = detailsStorage;
            _detailPerSecondInfo = detailPerSecondInfo;
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

            foreach (KeyValuePair<DetailModel, ReactiveProperty<float>> keyValue in _detailsStorage
                         .DetailsCount)
            {
                if (!keyValue.Key.Available) return;
                
                _uiFactory.CreateUpgradeDetailButton(transform, keyValue.Key,
                    _detailPerSecondInfo.DetailsPerSeconds[keyValue.Key]);
            }
        }
    }
}
