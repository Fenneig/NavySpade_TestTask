using UnityEngine;

namespace NavySpade.Components
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int _amount;

        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public void Apply(GameObject target)
        {
            var targetHealth = target.GetComponent<HealthComponent>();
            if (targetHealth != null) targetHealth.ReceiveDamage(_amount);
        }
    }
}