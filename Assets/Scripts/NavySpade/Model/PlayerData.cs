using System;
using NavySpade.Model.Properties;
using UnityEngine;

namespace NavySpade.Model
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private IntProperty _hp;
        [SerializeField] private float _speed;

        public IntProperty Hp => _hp;

        public int Speed { get; set; }
    }
}