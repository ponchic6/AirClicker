using System;
using UnityEngine;

namespace Utilites
{   
    [Serializable]
    public class AircraftSerializableDictionary
    {
        [SerializeField] private AircraftSerializableItem[] aircraftSerializableItem;

        public AircraftSerializableItem[] AircraftSerializableItem => aircraftSerializableItem;
    }
}