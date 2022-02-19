using UnityEngine;

namespace NavySpade.Components
{
    public class InvulnerableEffectComponent : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private int _blinksAmount;
    }
}