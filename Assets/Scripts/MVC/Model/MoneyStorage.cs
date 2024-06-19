using UniRx;
using UnityEngine;

namespace MVC.Model
{
    public class MoneyStorage : IMoneyStorage
    {
        private readonly ReactiveProperty<float> _money = new();

        public ReactiveProperty<float> Money => _money;
    }
}