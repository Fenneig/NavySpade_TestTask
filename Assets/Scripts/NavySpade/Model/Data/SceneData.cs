using System;
using UnityEngine;

namespace NavySpade.Model.Data
{
    [Serializable]
    public class SceneData
    {
        [SerializeField] private int _maxEnemiesOnScene;
        [SerializeField] private int _maxCrystalsOnScene;

        public int MaxEnemiesOnScene => _maxEnemiesOnScene;
        public int MaxCrystalsOnScene => _maxCrystalsOnScene;
        
        public int CurrentEnemiesOnScene { get; set; }
        public int CurrentCrystalsOnScene { get; set; }
    }
}