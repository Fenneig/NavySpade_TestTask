using UnityEngine;
using UnityEngine.UI;

namespace NavySpade
{
    public class BestScore : MonoBehaviour
    {
        [SerializeField] private Text _bestScore;
        private void Start()
        {
            _bestScore.text += PlayerPrefs.GetInt("Score").ToString();
        }
    }
}