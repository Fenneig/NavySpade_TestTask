using System;
using NavySpade.Model.Data.Properties;
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

        public IntProperty CurrentEnemiesOnScene { get; set; }
        public IntProperty CurrentCrystalsOnScene { get; set; }

        public void InitData()
        {
            CurrentEnemiesOnScene = new IntProperty {Value = 0};
            CurrentCrystalsOnScene = new IntProperty {Value = 0};
        }
    }
}