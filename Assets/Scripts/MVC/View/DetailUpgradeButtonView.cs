using System;
using System.Collections.Generic;
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

        [Inject]
        public void Constructor()
        {
            
        }

        public void Initialize(Sprite detailModelSprite, ReactiveProperty<float> perSecond,
            ReactiveProperty<float> count)
        {
            icon.sprite = detailModelSprite;
            
            perSecond.Subscribe(value =>
            {
                currentDetailPerSecond.text = value.ToString();
            }).AddTo(_disposables);
            
            count.Subscribe(value =>
            {
                detailCount.text = value.ToString();
            }).AddTo(_disposables);
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
