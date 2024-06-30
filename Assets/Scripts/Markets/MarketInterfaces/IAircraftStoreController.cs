using Aircraft;

namespace Markets.MarketInterfaces
{
    public interface IAircraftStoreController
    {
        public bool TrySellAircraft(AircraftModel aircraftModel);
    }
}