using System;
using NavySpade.Model.Data.Properties;
using UnityEngine;

namespace NavySpade.Model.Data
{
    [Serializable]
    public class DistanceData
    {
        [SerializeField] private FloatProperty _nearestEnemy;
        [SerializeField] private FloatProperty _nearestCrystal;
        public FloatProperty NearestEnemy => _nearestEnemy;
        public FloatProperty NearestCrystal => _nearestCrystal;
    }
}