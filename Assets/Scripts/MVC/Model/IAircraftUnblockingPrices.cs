using System.Collections.Generic;

namespace MVC.Model
{
    public interface IAircraftUnblockingPrices
    { 
        public Dictionary<AircraftModel, float> UnblockingPricesDict { get; }
    }
}