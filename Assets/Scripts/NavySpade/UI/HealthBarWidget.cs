using UnityEngine;

namespace NavySpade.UI
{
    public class HealthBarWidget : MonoBehaviour
    {
        [SerializeField] private GameObject[] _hearts;
        
        public void SetHealth(int value)
        {
            for (var i = 0; i < _hearts.Length; i++)
            {
                _hearts[i].SetActive(false);
            }
            for (var i = 0; i < value; i++)
            {
                _hearts[i].SetActive(true);
            }    
        }
    }
}