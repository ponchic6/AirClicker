using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Utilites
{   
    [Serializable]
    public class AircraftItemsContainer
    {
        [SerializeField] private AircraftItem[] aircraftItem;

        public AircraftItem[] AircraftItem => aircraftItem;
    }
}