using UniRx;

namespace Storages
{
    public class MoneyStorage : IMoneyStorage
    {
        private readonly ReactiveProperty<float> _money = new();

        public ReactiveProperty<float> Money => _money;
    }
}