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
    public class DetailUpgradeButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text currentDetailPerSecond;
        [SerializeField] private TMP_Text detailCount;
        [SerializeField] private Button upgradeButton;
        [SerializeField] private Image icon;

        private List<IDisposable> _disposables = new List<IDisposable>();
        private IDetailUpgradeStore _detailUpgradeStore;
        private IUpgradePriceModel _upgradePriceModel;
        private DetailModel _detailModel;

        [Inject]
        public void Constructor(IDetailUpgradeStore detailUpgradeStore, IUpgradePriceModel upgradePriceModel)
        {
            _upgradePriceModel = upgradePriceModel;
            _detailUpgradeStore = detailUpgradeStore;
        }

        public void Initialize(DetailModel detailModel, Sprite detailModelSprite, ReactiveProperty<float> perSecond,
            ReactiveProperty<float> count)
        {
            _detailModel = detailModel;
            icon.sprite = detailModelSprite;
            
            perSecond.Subscribe(value =>
            {
                currentDetailPerSecond.text = value + " в сек.";
            }).AddTo(_disposables);
            
            count.Subscribe(value =>
            {
                detailCount.text = decimal.Round((decimal)value, 2) + " шт.";
            }).AddTo(_disposables);
            
            _upgradePriceModel.PricesUpgradeModelDictionary[detailModel].Subscribe(value =>
            {
                upgradeButton.gameObject.GetComponentInChildren<TMP_Text>().text = value + " $";
            }).AddTo(_disposables);

            upgradeButton.onClick.AddListener(() =>
            {
                _detailUpgradeStore.Upgrade(_detailModel);
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
