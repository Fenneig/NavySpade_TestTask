using System;
using NavySpade.Model;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace NavySpade.Components.Enemy
{
    public class EnemyComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _speed;
        [Space][Header("Field size")] 
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _minZ;
        [SerializeField] private float _maxZ;

        private void Start()
        {
            _agent.speed = _speed;
        }

        private Vector3 GenerateNewDestination()
        {
            var newX = Random.Range(_minX, _maxX);
            var newZ = Random.Range(_minZ, _maxZ);
            return new Vector3(newX, 0, newZ);
        }

        private void Update()
        {
            if (!_agent.hasPath) _agent.SetDestination(GenerateNewDestination());
        }

        private void OnDestroy()
        {
            GameSession.Instance.SceneData.CurrentEnemiesOnScene.Value--;
        }
    }
}