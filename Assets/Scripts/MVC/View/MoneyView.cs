using System;
using System.Collections.Generic;
using MVC.Model;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace MVC.View
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text money;
        private IMoneyStorage _moneyStorage;
        private IList<IDisposable> _disposables = new List<IDisposable>();

        [Inject]
        public void Constructor(IMoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }

        private void Start()
        {
            _moneyStorage.Money.Subscribe(value =>
            {
                money.text = value.ToString();
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
