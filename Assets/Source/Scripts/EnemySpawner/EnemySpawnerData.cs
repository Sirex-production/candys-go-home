using Candy.Enemy;
using NaughtyAttributes;
using UnityEngine;

namespace Candy.Spawner
{
    [CreateAssetMenu(menuName = "Enemy/Spawner/Data")]
    public class EnemySpawnerData : ScriptableObject
    {
        [SerializeField] 
        [Required] 
        private EnemyActor spawnableEnemy;

        [SerializeField] 
        [Min(0)] 
        private float timeToSpawn;
        
        [SerializeField] 
        [Min(0)] 
        private int amountOfEnemiesPerSpawn;

        public EnemyActor SpawnableEnemy => spawnableEnemy;

        public float TimeToSpawn => timeToSpawn;

        public int AmountOfEnemiesPerSpawn => amountOfEnemiesPerSpawn;
    }
}