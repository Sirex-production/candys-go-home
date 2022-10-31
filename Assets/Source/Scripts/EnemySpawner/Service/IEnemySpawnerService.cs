using UnityEngine;

namespace Candy.Spawner.Service
{
    public interface IEnemySpawnerService
    {
        public Transform GetTarget(); 
        public void SpawnEnemy();
    }
}