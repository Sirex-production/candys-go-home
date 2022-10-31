using System;
using UnityEngine;

namespace Candy.Support
{
    public sealed class SphereVisualizer : MonoBehaviour
    {
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, 1);
        }
    }
}