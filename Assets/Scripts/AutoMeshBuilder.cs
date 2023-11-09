using Unity.AI.Navigation;
using UnityEngine;

namespace ShadowChimera
{
    public class AutoMeshBuilder : MonoBehaviour
    {
        private void Awake()
        {
            var surfaces = GetComponents<NavMeshSurface>();
            foreach (var surface in surfaces)
            {
                surface.BuildNavMesh();
            }
        }
    }
}
