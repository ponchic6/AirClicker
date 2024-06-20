using UnityEngine;

namespace StaticData
{   
    [CreateAssetMenu(menuName = "StaticData/DetailModelSO", fileName = "DetailModelSO")]
    public class DetailModelSO : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private Sprite sprite;
        [SerializeField] private float initialUpgradePrice;
        [SerializeField] private float upgradeValue;

        public string ID => id;
        public Sprite Sprite => sprite;
        public float InitialUpgradePrice => initialUpgradePrice;
        public float UpgradeValue => upgradeValue;
    }
}