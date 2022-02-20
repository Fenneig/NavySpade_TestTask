using System;
using NavySpade.Model.Data.Properties;
using UnityEngine;

namespace NavySpade.Model.Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private IntProperty _hp;
        [SerializeField] private float _speed;
        [SerializeField] private IntProperty _score;

        public IntProperty Hp => _hp;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public IntProperty Score => _score;
    }
}