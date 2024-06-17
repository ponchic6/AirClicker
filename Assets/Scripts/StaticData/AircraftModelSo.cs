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

        public Sprite Sprite => sprite;
        public AircraftSerializableDictionary DetailsDictionary => detailsDictionary;
        public string Id => id;
    } 
}