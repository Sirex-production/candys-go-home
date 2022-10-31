using System;
using System.Collections.Generic;
using Candy.Enemy;
using Candy.Spawner;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Candy.Wave
{
    public sealed class WaveService : MonoBehaviour , IWaveService
    {
        [SerializeField] 
        private List<EnemySpawner> spawners;
        
        [SerializeField]
        private int numberOfEnemies = 10;

        [SerializeField] 
        private int additionalNumberOfEnemiesPerWave = 4;

        [SerializeField] private EnemyCategoryConfig categoryConfig;

        private float respawnInterval = 3f;
        private float currentRespawnInterval = 0f;
        public event Action OnNextWave;
        private int _waveNumber = 1;
        
        private int _currentSpawnedEnemies = 0;
        private int _enemiesLeft = 0;

        private void Start()
        {
            _enemiesLeft = FindObjectsOfType<EnemyActor>().Length;
        }

        public void PerformNextWave()
        {
            _currentSpawnedEnemies = 0;
            currentRespawnInterval = 0;
            _waveNumber++;
            numberOfEnemies += additionalNumberOfEnemiesPerWave;
            OnNextWave?.Invoke();
        }

        public void EnemyKilled()
        {
            _enemiesLeft--;
        }

        private void Update()
        {
            //next wave
            if (_enemiesLeft<=0 && _currentSpawnedEnemies >= numberOfEnemies)
            {
                PerformNextWave();
            }
            Debug.Log($"{_currentSpawnedEnemies} {numberOfEnemies}");
            //w8 for player clear
            if (_currentSpawnedEnemies >= numberOfEnemies )
            {
                return;
            }
            //interval
            currentRespawnInterval += Time.deltaTime;
            if (!(currentRespawnInterval >= respawnInterval)) return;
            
            currentRespawnInterval = 0;
            //spawn
            spawners[Random.Range(0,spawners.Count)].SpawnEnemy(categoryConfig.TypeOfEnemies[Random.Range(0,categoryConfig.TypeOfEnemies.Count)]);
            _currentSpawnedEnemies++;
            _enemiesLeft++;

        }
    }
}