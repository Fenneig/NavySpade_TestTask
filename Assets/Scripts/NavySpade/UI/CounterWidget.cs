using UnityEngine;
using UnityEngine.UI;

namespace NavySpade.UI
{
    public class CounterWidget : MonoBehaviour
    {
        [SerializeField] private Text _distanceText;
        [SerializeField] private Text _amountText;

        public void SetDistance(float distance)
        {
            _distanceText.text = distance.ToString("#.0");
        }

        public void SetAmount(int amount)
        {
            _amountText.text = amount.ToString();
        }

    }
}