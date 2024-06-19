using UniRx;

namespace MVC.Model
{
    public interface IMoneyStorage
    {
        public ReactiveProperty<float> Money { get; }
    }
}