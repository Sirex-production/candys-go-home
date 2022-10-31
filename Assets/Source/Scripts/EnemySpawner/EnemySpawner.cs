using System;
using System.Collections.Generic;
using Candy.Enemy;
using Candy.Projectile;
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
        
        private List<IObjectPool<EnemyActor>> _pools = new();
        private bool _isBlocked = false;
        private DiContainer _diContainer;
        private List<float> _timers = new ();
        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        private void Start()
        {
            for (int i = 0; i < data.Enemies.Count; i++)
            {
                _timers.Add(data.Enemies[i].TimeToSpawn);
                
                int index = i;
                var objectPool = new ObjectPool<EnemyActor>
                (
                    () => OnEnemyCreate(index),
                    OnEnemyGet,
                    OnEnemyRelease,
                    OnEnemyDestroy
                );
				
                _pools.Add(objectPool);
                
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
                Spawn(data.Enemies[i]);
                _timers[i] = data.Enemies[i].TimeToSpawn;
            }
        }

        private void Spawn(EnemySpawnerData enemySpawnerData)
        {
            var pref = enemySpawnerData; 
            var enemy = _diContainer.InstantiatePrefabForComponent<EnemyActor>(pref);
            //return enemy;
        }
        private EnemyActor OnEnemyCreate(int id)
        {
            var pref = data.Enemies[id].SpawnableEnemy; 
            var enemy = _diContainer.InstantiatePrefabForComponent<EnemyActor>(pref);
            return enemy;
        }

        private void OnEnemyGet(EnemyActor enemy)
        {
           
        }

        private void OnEnemyRelease(EnemyActor enemy)
        {
           
        }
		
        private void OnEnemyDestroy(EnemyActor enemy)
        {
             
        }
    }

  
    
}