using UnityEngine;

namespace NavySpade.Components
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        public void DestroyObject() => Destroy(gameObject);
    }
}