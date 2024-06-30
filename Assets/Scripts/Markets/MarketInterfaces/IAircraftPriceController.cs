using Aircraft;

namespace Markets.MarketInterfaces
{
    public interface IAircraftPriceController
    {
        public void StartDynamicPriceChange(AircraftModel aircraftModel);
    }
}