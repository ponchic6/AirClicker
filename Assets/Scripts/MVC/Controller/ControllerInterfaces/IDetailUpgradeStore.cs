using MVC.Model;

namespace MVC.Controller.ControllerInterfaces
{
    public interface IDetailUpgradeStore
    {
        public bool Upgrade(DetailModel detailModel);
    }
}