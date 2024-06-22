using MVC.Model;

namespace MVC.Controller
{
    public interface IDetailUpgradeStore
    {
        public bool Upgrade(DetailModel detailModel);
    }
}