using UnityEngine;

namespace StaticData
{   
    [CreateAssetMenu(menuName = "StaticData/DetailModelSO", fileName = "DetailModelSO")]
    public class DetailModelSO : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private Sprite sprite;

        public Sprite Sprite => sprite;
        public string ID => id;
    }
}