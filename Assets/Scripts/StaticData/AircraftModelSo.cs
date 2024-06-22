using UnityEngine;
using Utilites;

namespace StaticData
{   
    [CreateAssetMenu(menuName = "StaticData/AircraftModelSo", fileName = "AircraftModelSo")]
    public class AircraftModelSo : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private AircraftItemsContainer aircraftItemsContainer;
        [SerializeField] private string id;
        [SerializeField] private float initialPrice;
        [SerializeField] private bool availableOnStart;
        [SerializeField] private float unlockingPrice;

        public Sprite Sprite => sprite;
        public AircraftItemsContainer AircraftItemsContainer => aircraftItemsContainer;
        public string Id => id;
        public float InitialPrice => initialPrice;
        public bool AvailableOnStart => availableOnStart;
        public float UnblockingPrice => unlockingPrice;
    } 
}