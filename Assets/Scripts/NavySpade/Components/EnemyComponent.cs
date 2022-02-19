using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace NavySpade.Components
{
    public class EnemyComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [Space][Header("Move stats")] 
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _minZ;
        [SerializeField] private float _maxZ;

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
    }
}