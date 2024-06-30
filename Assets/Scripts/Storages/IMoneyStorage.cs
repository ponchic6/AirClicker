using UniRx;

namespace Storages
{
    public interface IMoneyStorage
    {
        public ReactiveProperty<float> Money { get; }
    }
}