using UnityEngine;

namespace MVC.Model
{
    public class DetailModel
    {
        public string Id { get; }
        public Sprite Sprite { get; }
        public float UpgradeValue { get; }

        public DetailModel(string id, Sprite sprite, float upgradeValue)
        {
            Id = id;
            Sprite = sprite;
            UpgradeValue = upgradeValue;
        }
    }
}