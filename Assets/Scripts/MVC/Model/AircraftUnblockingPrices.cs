using System.Collections.Generic;

namespace MVC.Model
{
    public class AircraftUnblockingPrices : IAircraftUnblockingPrices
    {
        private readonly Dictionary<AircraftModel, float> _unblockingPricesDict = new();

        public Dictionary<AircraftModel, float> UnblockingPricesDict => _unblockingPricesDict;
    }
}