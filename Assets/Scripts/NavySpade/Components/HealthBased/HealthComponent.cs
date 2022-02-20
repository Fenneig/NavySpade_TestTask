using NavySpade.Model.Data.Properties;
using UnityEngine;
using UnityEngine.Events;

namespace NavySpade.Components.HealthBased
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private IntProperty _hp;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] private UnityEvent _onDie;
        public int MaxHealth { get; set; }

        public IntProperty Hp
        {
            get => _hp;
            set => _hp = value;
        }

        public bool IsInvulnerable { get; set; }

        public void ReceiveDamage(int amount)
        {
            if (_hp.Value < 0 || IsInvulnerable) return;
            _hp.Value -= amount;
            _onDamage?.Invoke();
            if (_hp.Value <= 0) _onDie?.Invoke();
        }

        public void ReceiveHeal(int amount)
        {
            if (_hp.Value + amount >= MaxHealth) _hp.Value = MaxHealth;
            else _hp.Value += amount;
            _onHeal?.Invoke();
        }
    }
}