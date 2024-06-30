using Detail;

namespace Markets.MarketInterfaces
{
    public interface IDetailUpgradeStore
    {
        public bool Upgrade(DetailModel detailModel);
    }
}