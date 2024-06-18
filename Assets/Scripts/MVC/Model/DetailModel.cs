using System;
using UnityEngine;

namespace MVC.Model
{
    public class DetailModel : IDetailModel
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