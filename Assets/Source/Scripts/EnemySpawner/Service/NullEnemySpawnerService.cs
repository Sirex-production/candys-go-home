using Candy.Enemy;
using UnityEngine;

namespace Candy.Spawner.Service
{
    public sealed class NullEnemySpawnerService : IEnemySpawnerService
    {
        public Transform GetTarget()
        {
            return null;
        }

        public void SpawnEnemy(EnemyActor enemySpawnerData, Vector3 position)
        {
            
        }

        public void ResetEnemy(EnemyActor enemySpawnerData)
        {
             
        }
    }
}