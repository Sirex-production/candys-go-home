using UnityEngine;

namespace Candy.Enemy
{
    [CreateAssetMenu(menuName = "Enemy/Data")]
    public sealed class EnemyData : ScriptableObject
    {
        //--------- Attack ----------
        [Header("Attack")]
        [SerializeField] 
        [Min(0)]
        private float damage;
        
        [SerializeField] 
        [Min(0)]
        private float attackSpeed;
        
        [SerializeField] 
        [Min(0)]
        private float attackRange;
        
        [SerializeField] 
        [Min(0)]
        private float attackInterval;

        //--------- Detection ----------
        [Header("Detection")]
        [SerializeField] 
        [Min(0)] 
        private float chaseDetectionRange;
        
        [Header("Detection")]
        [SerializeField] 
        [Min(0)] 
        private float attackDetectionRange;
        
        //--------- Health ----------
        [Header("Health")]
        [SerializeField] 
        [Min(0)]
        private float maxHealth;
        
        //--------- Movement ----------
        [Header("Health")]
        [SerializeField] 
        [Min(0)]
        private float movementSpeed;


        public float Damage => damage;

        public float AttackSpeed => attackSpeed;

        public float AttackRange => attackRange;

        public float AttackInterval => attackInterval;

        public float MaxHealth => maxHealth;

        public float MovementSpeed => movementSpeed;

        public float ChaseDetectionRange => chaseDetectionRange;

        public float AttackDetectionRange => attackDetectionRange;
    }
}