﻿using System.Collections.Generic;
using UniRx;

namespace MVC.Model
{
    public interface IAircraftStorage
    {
        public Dictionary<AircraftModel, ReactiveProperty<float>> AircraftCountDictionary { get; }
    }
}