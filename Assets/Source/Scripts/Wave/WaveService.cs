using System;
using UnityEngine;

namespace Candy.Wave
{
    public sealed class WaveService : MonoBehaviour
    {
        [SerializeField]
        private int numberOfEnemies = 10;

        [SerializeField] 
        private int additionalNumberOfEnemiesPerWave = 4;

        public event Action OnNextWave;
        private int _waveNumber = 1;
        
        private int _currentSpawnedEnemies = 0;
        
        public void PerformNextWave()
        {
            _currentSpawnedEnemies = 0;
            _waveNumber++;
            numberOfEnemies += additionalNumberOfEnemiesPerWave;
            OnNextWave?.Invoke();
        }
        
    }
}