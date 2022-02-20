using NavySpade.Model;
using UnityEngine;

namespace NavySpade.Components.Enemy
{
    public class EnemySpawnerComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        private DistanceCounterComponent _distanceCounter;

        private void Start()
        {
            _distanceCounter = FindObjectOfType<DistanceCounterComponent>();
        }

        public void SpawnEnemy()
        {
            var instance = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            _distanceCounter.AddEnemy(instance.transform);
            GameSession.Instance.SceneData.CurrentEnemiesOnScene.Value++;
        }
    }
}