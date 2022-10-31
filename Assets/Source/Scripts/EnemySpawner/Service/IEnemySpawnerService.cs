using Candy.Enemy;
using UnityEngine;

namespace Candy.Spawner.Service
{
    public interface IEnemySpawnerService
    {
        public Transform GetTarget(); 
        public void SpawnEnemy(EnemyActor enemySpawnerData, Vector3 position);
        public void ResetEnemy(EnemyActor enemySpawnerData);
    }
}