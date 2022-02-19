using System.Collections;
using NavySpade.Model;
using NavySpade.Model.Data;
using UnityEngine;

namespace NavySpade.Components.Enemy
{
    public class EnemySpawnerControllerComponent : MonoBehaviour
    {
        [SerializeField] private int _timeBetweenSpawn;
        private EnemySpawnerComponent[] _spawners;
        private SceneData _sceneData;
        private bool _isSpawnInProcess;

        private void Start()
        {
            _spawners = FindObjectsOfType<EnemySpawnerComponent>();
            _sceneData = GameSession.Instance.SceneData;
        }

        private void Update()
        {
            if (!_isSpawnInProcess && _sceneData.CurrentEnemiesOnScene < _sceneData.MaxEnemiesOnScene)
            {
                _isSpawnInProcess = true;
                StartCoroutine(SpawnEnemy());
            }
        }

        private IEnumerator SpawnEnemy()
        {
            while (_sceneData.CurrentEnemiesOnScene < _sceneData.MaxEnemiesOnScene)
            {
                var randomSpawner = _spawners[Random.Range(0, _spawners.Length)];
                randomSpawner.SpawnEnemy();
                yield return new WaitForSeconds(_timeBetweenSpawn);
            }

            _isSpawnInProcess = false;
        }
    }
}