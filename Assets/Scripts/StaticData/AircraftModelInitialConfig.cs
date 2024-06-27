using System;
using UnityEngine;
using UnityEngine.Serialization;
using Utilites;

namespace StaticData
{   
    [CreateAssetMenu(menuName = "StaticData/AircraftModelSo", fileName = "AircraftModelSo")]
    public class AircraftModelInitialConfig : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private AircraftItemsContainer aircraftItemsContainer;
        [SerializeField] private string id;
        [SerializeField] private float basePrice;
        [SerializeField] private bool availableOnStart;
        [SerializeField] private float unlockingPrice;

        public Sprite Sprite => sprite;
        public AircraftItemsContainer AircraftItemsContainer => aircraftItemsContainer;
        public string Id => id;
        public float BasePrice => basePrice;
        public bool AvailableOnStart => availableOnStart;
        public float UnblockingPrice => unlockingPrice;

        private void OnValidate()
        {
            float totalDetailCount = 0;
            
            foreach (AircraftItem aircraftItem in aircraftItemsContainer.AircraftItem)
            {
                //aircraftItem.DetailModel.initialUpgradePrice = basePrice;
                totalDetailCount += aircraftItem.Count;
                aircraftItem.DetailModel.upgradeValue = (float)aircraftItem.Count / 10;
            }
            
            foreach (AircraftItem aircraftItem in aircraftItemsContainer.AircraftItem)
            {
                aircraftItem.DetailModel.initialUpgradePrice = (totalDetailCount / aircraftItem.Count ) * basePrice;
            }
        }
    } 
}