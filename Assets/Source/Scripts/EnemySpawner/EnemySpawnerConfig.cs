using System;
using System.Collections.Generic;
using Candy.Enemy;
using NaughtyAttributes;
using UnityEngine;

namespace Candy.Spawner
{
    [CreateAssetMenu(menuName = "Enemy/Spawner/Config")]
    public sealed class EnemySpawnerConfig: ScriptableObject
    {
        [SerializeField] public List<EnemySpawnerData> enemies;

        public List<EnemySpawnerData> Enemies => enemies;
    }

   
    
}