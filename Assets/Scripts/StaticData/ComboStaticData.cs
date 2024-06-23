using UnityEngine;

namespace StaticData
{   
    [CreateAssetMenu(menuName = "StaticData/ComboStaticData", fileName = "ComboStaticData")]
    public class ComboStaticData : ScriptableObject
    {
        public float maxBoost;
        public float increaseForOneClick;
        public AnimationCurve decreaseDependence;
        public float decreaseMultiplier;
    }
}