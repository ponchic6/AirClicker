using UnityEngine;

namespace StaticData
{   
    [CreateAssetMenu(menuName = "StaticData/DetailModelSO", fileName = "DetailModelSO")]
    public class DetailModelSO : ScriptableObject
    {
        public string id;
        public Sprite sprite;
        public float initialUpgradePrice;
        public float upgradeValue;
    }
}