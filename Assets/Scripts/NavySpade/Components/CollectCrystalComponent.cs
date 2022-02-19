using NavySpade.Components.HealthBased;
using NavySpade.Model;
using UnityEngine;

namespace NavySpade.Components
{
    public class CollectCrystalComponent : MonoBehaviour
    {
        [SerializeField] private int _healAmount;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            
            var crystalData = GameSession.Instance.CrystalData;
            var randomScoreAmount = Random.Range(crystalData.MinScore, crystalData.MaxScore);
            other.GetComponent<HealthComponent>().ReceiveHeal(_healAmount);
            GameSession.Instance.Data.Score += randomScoreAmount;
        }
        
        public void ReduceCrystalsOnScene()
        {
            GameSession.Instance.SceneData.CurrentCrystalsOnScene--;
        }
    }
}