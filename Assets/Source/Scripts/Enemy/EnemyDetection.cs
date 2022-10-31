using System;
using UnityEngine;

namespace Candy.Enemy
{
    public sealed class EnemyDetection : MonoBehaviour
    {
        public event Action OnEnter;
        public event Action OnExit;
        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
             OnEnter?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            OnExit?.Invoke();
            
        }
    }
}