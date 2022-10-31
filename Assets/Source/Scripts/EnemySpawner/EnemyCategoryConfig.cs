using System.Collections.Generic;
using Candy.Enemy;
using UnityEngine;

namespace Candy.Spawner
{
    [CreateAssetMenu(menuName = "Enemy/Spawner/CategoryConfig")]
    public class EnemyCategoryConfig : ScriptableObject
    {
        [SerializeField]
        private List<EnemyActor> typeOfEnemies;

        public List<EnemyActor> TypeOfEnemies => typeOfEnemies;
    }
}