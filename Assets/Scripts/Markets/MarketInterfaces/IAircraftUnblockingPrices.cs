using System.Collections.Generic;
using Aircraft;

namespace Markets.MarketInterfaces
{
    public interface IAircraftUnblockingPrices
    { 
        public Dictionary<AircraftModel, float> UnblockingPricesDict { get; }
    }
}