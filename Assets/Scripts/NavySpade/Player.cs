using NavySpade.Components.HealthBased;
using NavySpade.Model;
using UnityEngine;
using UnityEngine.AI;

namespace NavySpade
{
    public class Player : MonoBehaviour
    {
        [Space] [Header("Specifications")] [SerializeField]
        private NavMeshAgent _agent;

        [SerializeField] private Animator _animator;
        [SerializeField] private HealthComponent _health;

        private Vector3 _destination;
        private static readonly int IsRunning = Animator.StringToHash("is-running");

        private GameSession _session;

        public void Move(Vector3 destination)
        {
            _destination = destination;
        }

        private void Start()
        {
            _session = GameSession.Instance;
            _health.MaxHealth = _session.Data.Hp.Value;
            _health.Hp = _session.Data.Hp;
        }

        private void Update()
        {
            _agent.speed = _session.Data.Speed;

            _agent.SetDestination(_destination);
            _animator.SetBool(IsRunning, _agent.hasPath);
        }
    }
}