using System;
using Candy.Actors;
using Candy.Projectile;
using Candy.Spawner.Service;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Zenject;

namespace Candy.Enemy
{
    public sealed class EnemyActor : MonoBehaviour
    {
        // -------- data ----------
        [FormerlySerializedAs("data")]
        [SerializeField] 
        [Required] 
        private EnemyConfig config;
        
        private IProjectileService _projectile;
        private IEnemySpawnerService _enemySpawnerService;
        
        // -------- components ----------
        [SerializeField] 
        [Required] 
        private NavMeshAgent navMeshAgent;
        
        [SerializeField] 
        [Required] 
        private ActorHealth actorHealth;

        [SerializeField] 
        [Required]
        private EnemyAttack enemyAttack;
        
        [SerializeField] 
        [Required] 
        private EnemyDetection detectionTrigger ;
        
        [SerializeField] 
        [Required] 
        private EnemyDetection attackTrigger ;
        
        
        // -------- detecting ----------
        [SerializeField] 
        [Required]
        private SphereCollider detectionZone;
        
        [SerializeField] 
        [Required]
        private SphereCollider attackZone;
        
        [SerializeField] 
        public Transform target;
        
        // -------- 
        private bool _isDead = false;
        // --------
        public EnemyConfig Config => config;
        public NavMeshAgent NavMeshAgent => navMeshAgent;

        public EnemyAttack EnemyAttack => enemyAttack;

        public bool IsTargetDetected()
        {
            var dir = target.position - transform.position;
            dir.y = 0;
            var deltaAngle = Vector3.Angle(dir, transform.forward);
            if (deltaAngle >= config.ConeOfVision || deltaAngle < 0)
            {
                return false;
            }
            return detectionTrigger.IsPlayerDetected;
             
        }

        public bool IsTargetInAttackRange => attackTrigger.IsPlayerDetected;

        public ActorHealth ActorHealth => actorHealth;

        public bool IsDead => _isDead;

            
        [Inject]
        private void Construct(IProjectileService projectileService, IEnemySpawnerService enemySpawnerService)
        {
            _projectile = projectileService;
            _enemySpawnerService = enemySpawnerService;
            target = enemySpawnerService.GetTarget();
        }
        
        private void Start()
        {
            actorHealth.InitHealth(config.MaxHealth); 
            detectionZone.radius = config.ChaseDetectionRange;
            attackZone.radius = config.AttackDetectionRange;
            
            actorHealth.OnDie += () => _isDead = true;
        }
    }
}