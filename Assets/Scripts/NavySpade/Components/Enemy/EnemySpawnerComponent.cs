using NavySpade.Model;
using UnityEngine;

namespace NavySpade.Components.Enemy
{
    public class EnemySpawnerComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        public void SpawnEnemy()
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            GameSession.Instance.SceneData.CurrentEnemiesOnScene++;
        }
    }
}