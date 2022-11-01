using System;
using System.Collections;
using System.Collections.Generic;
using Candy.Enemy;
using Candy.Spawner;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


namespace Candy.Wave
{
    public sealed class WaveService : MonoBehaviour , IWaveService
    {

        [FormerlySerializedAs("_sec")] [SerializeField] private float secondsLeft = 120f;
        [SerializeField] 
        private List<EnemySpawner> spawners;
        
        [SerializeField]
        private int numberOfEnemies = 10;

        [SerializeField] 
        private int additionalNumberOfEnemiesPerWave = 4;

        [SerializeField] private EnemyCategoryConfig categoryConfig;
        [SerializeField] private int wavesToClear = 5 ;
        public event Action OnStageFinish;

        private bool _shouldBeBlocked = false;
        private float respawnInterval = 2.5f;
        private float currentRespawnInterval = 0f;
        public event Action OnNextWave;
        private int _waveNumber = 1;
        
        private int _currentSpawnedEnemies = 0;
        private int _enemiesLeft = 0;
        private float _time = 0;
        private Coroutine _coroutine;
        private void Start()
        {
            _enemiesLeft = FindObjectsOfType<EnemyActor>().Length;
            /*_coroutine = StartCoroutine(StartNewWave());*/
            _time = 0;
        }

        public void PerformNextWave()
        {
            /*_currentSpawnedEnemies = 0;
            currentRespawnInterval = 0;
            _waveNumber++;
            numberOfEnemies += additionalNumberOfEnemiesPerWave;
            OnNextWave?.Invoke();*/
        }

        public void EnemyKilled()
        {
            _enemiesLeft--;
        }
        
        private void Update()
        {
            
            currentRespawnInterval += Time.deltaTime;
            
            if (!(currentRespawnInterval >= respawnInterval)) return;
            
            currentRespawnInterval = 0;
            _time += Time.deltaTime;
            if (_time>= secondsLeft)
            {
                OnStageFinish?.Invoke();
            }

            /*if (_shouldBeBlocked)
            {
                return;
            }
            //next wave
            if (_enemiesLeft<=0 && _currentSpawnedEnemies >= numberOfEnemies)
            {
                if (_waveNumber >= wavesToClear)
                {
                    _shouldBeBlocked = true;
                    OnStageFinish?.Invoke();
                    return;
                }
                PerformNextWave();
            }
            //Debug.Log($"{_currentSpawnedEnemies} {numberOfEnemies}");
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
            _enemiesLeft++;*/

        }

        /*private IEnumerator StartNewWave()
        {
            for (int i = 0; i < wavesToClear; i++)
            {
                yield return new WaitForSeconds(25);
                PerformNextWave();
            }
            OnStageFinish?.Invoke();
        }*/
    }
}