using System;
using MVC.Model;
using StaticData;
using UnityEngine;

namespace Utilites
{
    [Serializable]
    public class AircraftItem
    {
        [SerializeField] private DetailModelSO detailModel;
        [SerializeField] private int count;

        public DetailModelSO DetailModel => detailModel;
        public int Count => count;
    }
}