using System.Collections;
using NavySpade.Model;
using NavySpade.Model.Data;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace NavySpade.Components
{
    //TODO: выделить базовый класс и убарть дублирующийся код
    public class CrystalSpawnerControllerComponent : MonoBehaviour
    {
        [SerializeField] private int _timeBetweenSpawn;
        [SerializeField] private int _initialSpawnCount;
        [SerializeField] private GameObject _crystalPrefab;
        private DistanceCounterComponent _distanceCounter;
        private SceneData _sceneData;
        private bool _isSpawnInProcess;

        private static float Range = 10.0f;

        private void Start()
        {
            _sceneData = GameSession.Instance.SceneData;
            _distanceCounter = FindObjectOfType<DistanceCounterComponent>();
            for (var i = 0; i < _initialSpawnCount; i++)
            {
                if (_sceneData.CurrentCrystalsOnScene.Value < _sceneData.MaxCrystalsOnScene) SpawnCrystal();
            }
        }

        private bool RandomPoint(Vector3 center, float range, out Vector3 result)
        {
            var isPositionFound = false;

            while (!isPositionFound)
            {
                Vector3 randomPoint = center + Random.insideUnitSphere * range;
                if (NavMesh.SamplePosition(randomPoint, out var hit, 1.0f, NavMesh.AllAreas))
                {
                    var prefabY = _crystalPrefab.transform.position.y;
                    result = hit.position;
                    result.y = prefabY;
                    return true;
                }
            }

            result = Vector3.zero;
            return false;
        }

        private IEnumerator SpawnCrystalRoutine()
        {
            while (_sceneData.CurrentCrystalsOnScene.Value < _sceneData.MaxCrystalsOnScene)
            {
                SpawnCrystal();
                yield return new WaitForSeconds(_timeBetweenSpawn);
            }

            _isSpawnInProcess = false;
        }

        private void SpawnCrystal()
        {
            if (RandomPoint(transform.position, Range, out var position))
            {
                var instance = Instantiate(_crystalPrefab, position, Quaternion.identity);
                _distanceCounter.AddCrystal(instance.transform);
                _sceneData.CurrentCrystalsOnScene.Value++;
            }
        }

        private void Update()
        {
            if (!_isSpawnInProcess && _sceneData.CurrentCrystalsOnScene.Value < _sceneData.MaxCrystalsOnScene)
            {
                _isSpawnInProcess = true;
                StartCoroutine(SpawnCrystalRoutine());
            }
        }
    }
}