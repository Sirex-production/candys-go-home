using UnityEngine;

namespace Candy.Enemy
{
    public sealed class EnemyData : ScriptableObject
    {
        [SerializeField] private float damage;
        [SerializeField] private float maxHealth;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float movementSpeed;

        public float Damage => damage;

        public float MaxHealth => maxHealth;

        public float AttackSpeed => attackSpeed;

        public float MovementSpeed => movementSpeed;
    }
}