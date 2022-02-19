using UnityEngine;

namespace NavySpade.Components.HealthBased
{
    public class InvulnerableEffectComponent : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private int _blinksAmount;
    }
}