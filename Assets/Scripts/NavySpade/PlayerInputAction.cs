using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace NavySpade
{
    public class PlayerInputAction : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Player _player;

        public void OnMove(InputAction.CallbackContext context)
        {
            if (!context.started) return;
            
            var ray = _mainCamera.ScreenPointToRay(Touchscreen.current.position.ReadValue());

            if (Physics.Raycast(ray, out var hit))
            {
                _player.Move(hit.point);
            }
        }
    }
}