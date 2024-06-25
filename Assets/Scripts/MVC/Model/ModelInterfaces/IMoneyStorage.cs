using UniRx;

namespace MVC.Model.ModelInterfaces
{
    public interface IMoneyStorage
    {
        public ReactiveProperty<float> Money { get; }
    }
}