using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{   
    [CreateAssetMenu(menuName = "StaticData/AircraftModelsList", fileName = "AircraftModelsList")]
    public class AircraftModelsList : ScriptableObject
    {
        [SerializeField] private List<AircraftModelInitialConfig> aircraftModels;

        public List<AircraftModelInitialConfig> AircraftModels => aircraftModels;
    }
}
