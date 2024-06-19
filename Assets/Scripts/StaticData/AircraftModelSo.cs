using UnityEngine;
using Utilites;

namespace StaticData
{   
    [CreateAssetMenu(menuName = "StaticData/AircraftModelSo", fileName = "AircraftModelSo")]
    public class AircraftModelSo : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private AircraftSerializableDictionary detailsDictionary;
        [SerializeField] private string id;
        [SerializeField] private float initialPrice;
        [SerializeField] private bool availableOnStart;
        [SerializeField] private float unlockingPrice;

        public Sprite Sprite => sprite;
        public AircraftSerializableDictionary DetailsDictionary => detailsDictionary;
        public string Id => id;
        public float InitialPrice => initialPrice;
        public bool AvailableOnStart => availableOnStart;
        public float UnblockingPrice => unlockingPrice;
    } 
}