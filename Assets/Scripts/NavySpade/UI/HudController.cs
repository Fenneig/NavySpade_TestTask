using NavySpade.Model;
using UnityEngine;

namespace NavySpade.UI
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private HealthBarWidget _hpBar;

        private void Start()
        {
            GameSession.Instance.Data.Hp.Subscribe(OnHealthChanged);
        }

        private void OnHealthChanged(int newValue)
        {
            _hpBar.SetHealth(newValue);
        }
    }
}