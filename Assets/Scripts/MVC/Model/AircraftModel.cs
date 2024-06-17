using System;
using System.Collections.Generic;
using UnityEngine;

namespace MVC.Model
{
    public class AircraftModel
    {
        private readonly Dictionary<DetailModel, int> _creationRecipeDictionary;
        public Dictionary<DetailModel, int> CreationRecipeDictionary => _creationRecipeDictionary;
        public string Id { get; }
        public Sprite Sprite { get; }

        public AircraftModel(Dictionary<DetailModel, int> creationRecipeDictionary, string id, Sprite sprite)
        {
            _creationRecipeDictionary = creationRecipeDictionary;
            Sprite = sprite;
            Id = id;
        }
    }
}