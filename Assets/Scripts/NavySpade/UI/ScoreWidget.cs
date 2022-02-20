using UnityEngine;
using UnityEngine.UI;

namespace NavySpade.UI
{
    public class ScoreWidget : MonoBehaviour
    {
        [SerializeField] private Text _score;

        public void SetScore(int value)
        {
            _score.text = $": {value}";
        }
    }
}