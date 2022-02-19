using UnityEngine;

namespace NavySpade.Components.HealthBased
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int _amount;
        
        public void Apply(GameObject target)
        {
            var targetHealth = target.GetComponent<HealthComponent>();
            if (targetHealth != null) targetHealth.ReceiveDamage(_amount);
        }
    }
}