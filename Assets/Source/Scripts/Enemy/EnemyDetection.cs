using System;
using UnityEngine;

namespace Candy.Enemy
{
    public sealed class EnemyDetection : MonoBehaviour
    {
        private bool _isPlayerDetected;

        public bool IsPlayerDetected => _isPlayerDetected;

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            _isPlayerDetected = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            _isPlayerDetected = true;

        }
    }
}