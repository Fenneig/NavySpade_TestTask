using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace NavySpade
{
    public class CharacterInputAction : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Character _character;
        
        public void OnMove(InputAction.CallbackContext context)
        {
            
        }
    }
}