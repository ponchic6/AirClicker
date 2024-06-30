using System.Collections.Generic;
using Detail;
using UnityEngine;

namespace Aircraft
{
    public class AircraftModel
    {
        private readonly Dictionary<DetailModel, int> _creationRecipe;
        public Dictionary<DetailModel, int> CreationRecipe => _creationRecipe;
        public string Id { get; }
        public Sprite Sprite { get; }
        public bool IsAvailable { get; }

        public AircraftModel(Dictionary<DetailModel, int> creationRecipe, string id, Sprite sprite, bool isAvailable)
        {
            _creationRecipe = creationRecipe;
            Sprite = sprite;
            IsAvailable = isAvailable;
            Id = id;
        }
    }
}