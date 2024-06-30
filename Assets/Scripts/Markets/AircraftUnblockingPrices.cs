using System.Collections.Generic;
using Aircraft;
using Markets.MarketInterfaces;

namespace Markets
{
    public class AircraftUnblockingPrices : IAircraftUnblockingPrices
    {
        private readonly Dictionary<AircraftModel, float> _unblockingPricesDict = new();

        public Dictionary<AircraftModel, float> UnblockingPricesDict => _unblockingPricesDict;
    }
}