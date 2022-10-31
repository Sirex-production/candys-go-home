using UnityEngine;

namespace Candy.Support
{
#if UNITY_EDITOR
    public sealed class SphereVisualizer : MonoBehaviour
    {
        [SerializeField] [Range(0, 10)] private float radius = 1;  
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, radius);
        }
    }
#endif
}