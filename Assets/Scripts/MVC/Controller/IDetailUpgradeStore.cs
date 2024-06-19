using MVC.Model;

namespace MVC.Controller
{
    public interface IDetailUpgradeStore
    {
        public void Upgrade(DetailModel detailModel);
    }
}