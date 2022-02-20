using System.Collections;
using UnityEngine;

namespace NavySpade.Components.HealthBased
{
    public class InvulnerableEffectComponent : MonoBehaviour
    {
        [SerializeField] private float _invulnerableTime;
        [SerializeField] private HealthComponent _healthComponent;

        public void MakeInvulnerable()
        {
            _healthComponent.IsInvulnerable = true;
            StartCoroutine(InvulnerableEffect());
        }
        //тут должен был быть какой-то крутой визуальный эффект, но я не успел его сделать :)
        private IEnumerator InvulnerableEffect()
        {
            yield return new WaitForSeconds(_invulnerableTime);
            _healthComponent.IsInvulnerable = false;
        }
    }
}