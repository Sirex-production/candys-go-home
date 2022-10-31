using UnityEngine;

namespace Candy.Support
{
    public sealed class SphereVisualizer : MonoBehaviour
    {
        [SerializeField] [Range(0, 10)] private float radius = 1;  
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, radius);
        }
    }
}