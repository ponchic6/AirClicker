using UnityEngine;

namespace MVC.Model
{
    public class DetailModel
    {
        public string Id { get; }
        public Sprite Sprite { get; }

        public DetailModel(string id, Sprite sprite)
        {
            Id = id;
            Sprite = sprite;
        }
    }
}