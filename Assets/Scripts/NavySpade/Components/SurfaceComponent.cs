using UnityEngine;
using UnityEngine.AI;

namespace NavySpade.Components
{
    public class SurfaceComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface _navMeshSurface;

        private void Start()
        {
            _navMeshSurface.BuildNavMesh();
        }
    }
}