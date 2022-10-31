using System;
using System.Collections.Generic;
using Candy.Enemy;
using Candy.Projectile;
using Candy.Spawner.Service;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Candy.Spawner
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] 
        [Required] 
        private EnemySpawnerConfig data;
        
        private bool _isBlocked = false;
        private List<float> _timers = new ();
        private IEnemySpawnerService _enemySpawnerService;
        
        [Inject]
        private void Construct( IEnemySpawnerService enemySpawnerService)
        {
            _enemySpawnerService = enemySpawnerService;
        }
        
        private void Start()
        {
            for (int i = 0; i < data.Enemies.Count; i++)
            {
                _timers.Add(data.Enemies[i].TimeToSpawn);
            }
        }

        private void Update()
        {
            if (_isBlocked)
            {
                return;
            }
            for (int i = 0; i < _timers.Count; i++)
            {
                _timers[i] -= Time.deltaTime;
                if (_timers[i]>0) continue;
                _enemySpawnerService.SpawnEnemy(data.Enemies[i].SpawnableEnemy,this.transform.position);
                _timers[i] = data.Enemies[i].TimeToSpawn;
            }
        }
    }
    
}