using NavySpade.Model;
using NavySpade.Utils;
using UnityEngine;

namespace NavySpade.UI
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private HealthBarWidget _hpBar;
        [SerializeField] private ScoreWidget _score;
        [SerializeField] private CounterWidget _crystalCount;
        [SerializeField] private CounterWidget _enemiesCount;

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private void Start()
        {
            _trash.Retain(GameSession.Instance.Data.Hp.Subscribe(OnHealthChanged));
            _trash.Retain(GameSession.Instance.Data.Score.Subscribe(OnScoreChanged));
            _trash.Retain(GameSession.Instance.SceneData.CurrentCrystalsOnScene.Subscribe(OnCurrentCrystalsChanged));
            _trash.Retain(GameSession.Instance.SceneData.CurrentEnemiesOnScene.Subscribe(OnCurrentEnemiesChanged));
            _trash.Retain(GameSession.Instance.DistanceData.NearestCrystal.Subscribe(OnNearestCrystalChanged));
            _trash.Retain(GameSession.Instance.DistanceData.NearestEnemy.Subscribe(OnNearestEnemyChanged));
        }

        private void OnNearestEnemyChanged(float newValue)
        {
            _enemiesCount.SetDistance(newValue);
        }

        private void OnNearestCrystalChanged(float newValue)
        {
            _crystalCount.SetDistance(newValue);
        }

        private void OnCurrentEnemiesChanged(int newValue)
        {
            _enemiesCount.SetAmount(newValue);
        }

        private void OnCurrentCrystalsChanged(int newValue)
        {
            _crystalCount.SetAmount(newValue);
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
            _trash.Dispose();
        }
    }
}