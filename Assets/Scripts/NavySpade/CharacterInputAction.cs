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
            if (!context.started) return;
            
            var ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out var hit))
            {
                _character.Move(hit.point);
            }
        }
    }
}