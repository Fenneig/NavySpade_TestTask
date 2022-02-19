using System;
using UnityEngine;

namespace NavySpade.Model.Data
{
    [Serializable]
    public class CrystalData
    {
        [SerializeField] private int _minScoreByCrystal;
        [SerializeField] private int _maxScoreByCrystal;

        public int MinScore => _minScoreByCrystal;
        public int MaxScore => _maxScoreByCrystal;

    }
}