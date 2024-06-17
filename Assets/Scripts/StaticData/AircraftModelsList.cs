using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{   
    [CreateAssetMenu(menuName = "StaticData/AircraftModelsList", fileName = "AircraftModelsList")]
    public class AircraftModelsList : ScriptableObject
    {
        [SerializeField] private List<AircraftModelSo> aircraftModels;

        public List<AircraftModelSo> AircraftModels => aircraftModels;
    }
}
