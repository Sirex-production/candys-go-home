using System;
using UnityEngine;

namespace Candy.Spawner.Service
{
    public class EnemySpawnerService : MonoBehaviour , IEnemySpawnerService
    {
        [SerializeField]
        private Transform target;

        private void Awake()
        {
            if (target !=null)
            {
                return;
            }
            target = GameObject.FindWithTag("Player").transform;
        }

        public Transform GetTarget()
        {
            return target;
        }

        public void SpawnEnemy()
        {
             
        }
    }
}