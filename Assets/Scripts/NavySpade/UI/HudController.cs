using NavySpade.Model;
using UnityEngine;

namespace NavySpade.UI
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private HealthBarWidget _hpBar;
        [SerializeField] private ScoreWidget _score;

        private void Start()
        {
            GameSession.Instance.Data.Hp.Subscribe(OnHealthChanged);
            GameSession.Instance.Data.Score.Subscribe(OnScoreChanged);
        }

        private void OnScoreChanged(int newValue)
        {
            _score.SetScore(newValue);
        }

        private void OnHealthChanged(int newValue)
        {
            _hpBar.SetHealth(newValue);
        }

        private void OnDestroy()
        {
            //очень некрасиво выглядит, надо бы написать контейнер подписок который может отписываться красивее
            GameSession.Instance.Data.Hp.Subscribe(OnHealthChanged).Dispose();
        }
    }
}