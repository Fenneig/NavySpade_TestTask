using UnityEngine;
using UnityEngine.AI;

namespace NavySpade
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;
        private Vector3 _destination;
        private static readonly int IsRunning = Animator.StringToHash("is-running");

        public void Move(Vector3 destination)
        {
            _destination = destination;
        }

        private void Update()
        {
            _agent.SetDestination(_destination);
            _animator.SetBool(IsRunning, _agent.hasPath);
        }
    }
}
