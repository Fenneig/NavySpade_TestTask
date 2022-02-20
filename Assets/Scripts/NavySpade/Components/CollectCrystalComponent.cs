using NavySpade.Components.HealthBased;
using NavySpade.Model;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NavySpade.Components
{
    [RequireComponent(typeof(DestroyObjectComponent))]
    public class CollectCrystalComponent : MonoBehaviour
    {
        [SerializeField] private int _healAmount;

        public void CollectCrystal(GameObject target)
        {
            if (target.CompareTag("Player"))
            {
                var crystalData = GameSession.Instance.CrystalData;
                var randomScoreAmount = Random.Range(crystalData.MinScore, crystalData.MaxScore);
                target.GetComponent<HealthComponent>().ReceiveHeal(_healAmount);
                GameSession.Instance.Data.Score.Value += randomScoreAmount;
                
                if (GameSession.Instance.Data.Score.Value > PlayerPrefs.GetInt("Score"))
                    PlayerPrefs.SetInt("Score", GameSession.Instance.Data.Score.Value);
            }
            else if (target.CompareTag("Enemy"))
            {
                target.GetComponent<DestroyObjectComponent>().DestroyObject();
            }

            GetComponent<DestroyObjectComponent>().DestroyObject();
        }

        private void OnDestroy()
        {
            GameSession.Instance.SceneData.CurrentCrystalsOnScene.Value--;
        }
    }
}