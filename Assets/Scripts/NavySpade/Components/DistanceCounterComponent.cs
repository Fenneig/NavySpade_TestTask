using System.Collections.Generic;
using NavySpade.Model;
using UnityEngine;

namespace NavySpade.Components
{
    //тут какой-то спагетти код :(
    public class DistanceCounterComponent : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        private List<Transform> _crystalsTransform = new List<Transform>();
        private List<Transform> _enemiesTransform = new List<Transform>();

        public void AddEnemy(Transform enemyTransform)
        {
            _enemiesTransform.Add(enemyTransform);
        }

        public void AddCrystal(Transform crystalTransform)
        {
            _crystalsTransform.Add(crystalTransform);
        }

        private float CalculateNearestObjectInList(List<Transform> list)
        {
            for (var i = 0; i < list.Count; i++)
                if (list[i] == null) list.RemoveAt(i);

            if (list.Count == 0) return 0;

            var distance = float.MaxValue;
            foreach (var item in list)
            {
                var newDistance = Vector3.Distance(_playerTransform.position, item.position);
                if (newDistance < distance) distance = newDistance;
            }

            return distance;
        }

        private void Update()
        {
            GameSession.Instance.DistanceData.NearestCrystal.Value = CalculateNearestObjectInList(_crystalsTransform);
            GameSession.Instance.DistanceData.NearestEnemy.Value = CalculateNearestObjectInList(_enemiesTransform);
        }
    }
}