using System;
using System.Collections.Generic;
using Candy.Enemy;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Candy.Spawner.Service
{
    public class EnemySpawnerService : MonoBehaviour , IEnemySpawnerService
    {
        [SerializeField]
        private Transform target;

        [SerializeField] 
        private EnemyCategoryConfig enemyCategoryConfig;
        Dictionary<int,ObjectPool<EnemyActor>> _pools = new();

        private DiContainer _diContainer;
        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        private void Awake()
        {
            if (target !=null)
            {
                return;
            }
            target = GameObject.FindWithTag("Player").transform;
        }

        private void Start()
        {
            for (int i = 0; i < enemyCategoryConfig.TypeOfEnemies.Count; i++)
            {
                int index = i;
                var objectPool = new ObjectPool<EnemyActor>
                (
                    () => OnEnemyCreate(index),
                    OnEnemyGet,
                    OnEnemyRelease,
                    OnEnemyDestroy
                );
				
                _pools.Add(enemyCategoryConfig.TypeOfEnemies[i].Config.ID,objectPool);
            }
           
        }

        public Transform GetTarget()
        {
            return target;
        }

        private EnemyActor OnEnemyCreate(int id)
        {
            var pref = enemyCategoryConfig.TypeOfEnemies[id];
            var enemy = _diContainer.InstantiatePrefabForComponent<EnemyActor>(pref);
            enemy.BehaviorAgent.ResetBehaviour();
            return enemy;
        }

        private void OnEnemyGet(EnemyActor enemy)
        {
           //todo
        }

        private void OnEnemyRelease(EnemyActor enemy)
        {
            //todo
        }
		
        private void OnEnemyDestroy(EnemyActor enemy)
        {
             //todo
        }
        
        public void SpawnEnemy(EnemyActor actor ,Vector3 position)
        {
            var enemy = _pools[actor.Config.ID].Get();
            enemy.transform.position = position;
        }
        public void ResetEnemy(EnemyActor enemySpawnerData)
        {
            _pools[enemySpawnerData.Config.ID].Release(enemySpawnerData);
        }
       
    }
}