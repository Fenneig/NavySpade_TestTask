using System;
using NavySpade.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace NavySpade.Components
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer;

        [SerializeField] private EnterEvent _action;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsInLayer(_layer)) InvokeAction(other);
        }

        private void InvokeAction(Collider other)
        {
            _action?.Invoke(other.gameObject);
        }

        [Serializable]
        public class EnterEvent : UnityEvent<GameObject>
        {
        }
    }
}