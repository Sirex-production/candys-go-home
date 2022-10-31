using UnityEngine;

namespace Candy.Enemy
{
    public enum TypeOfAttack
    {
        Melee,
        Ranged
    }
    [CreateAssetMenu(menuName = "Enemy/Data")]
    public sealed class EnemyConfig : ScriptableObject
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

        [SerializeField] 
        private TypeOfAttack typeOfAttack;

        //--------- Detection ----------
        [Header("Detection")]
        [SerializeField] 
        [Min(0)] 
        private float chaseDetectionRange;
        
        [SerializeField] 
        [Min(0)] 
        private float attackDetectionRange;

        [SerializeField] 
        [Min(0)] 
        private float coneOfVision;

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
        
        public float ConeOfVision => coneOfVision;

        public TypeOfAttack TypeOfAttack => typeOfAttack;
    }
}