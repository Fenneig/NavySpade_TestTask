using System.Collections;
using NavySpade.Model;
using NavySpade.Model.Data;
using UnityEngine;

namespace NavySpade.Components
{
    public class EnemySpawnerComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private float _timeBetweenSpawns;

        private SceneData _sceneData;
        private bool _isSpawning;

        private void Start()
        {
            _sceneData = GameSession.Instance.SceneData;
        }

        private IEnumerator SpawnEnemies()
        {
            while (_sceneData.CurrentEnemiesOnScene < _sceneData.MaxEnemiesOnScene)
            {
                yield return new WaitForSeconds(_timeBetweenSpawns);
                CreateEnemy();
            }

            _isSpawning = false;
        }

        private void Update()
        {
            if (!_isSpawning && _sceneData.CurrentEnemiesOnScene < _sceneData.MaxEnemiesOnScene)
            {
                StartCoroutine(SpawnEnemies());
                _isSpawning = true;
            }
        }

        private void CreateEnemy()
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            _sceneData.CurrentEnemiesOnScene++;
        }
    }
}