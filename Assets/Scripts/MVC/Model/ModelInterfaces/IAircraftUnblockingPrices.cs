using System.Collections.Generic;

namespace MVC.Model.ModelInterfaces
{
    public interface IAircraftUnblockingPrices
    { 
        public Dictionary<AircraftModel, float> UnblockingPricesDict { get; }
    }
}