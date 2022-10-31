using System;
using Candy.Actors;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace Candy.Enemy
{
    public sealed class EnemyActor : MonoBehaviour
    {
        // -------- data ----------
        [SerializeField] 
        [Required] 
        private EnemyData data;
        
        // -------- components ----------
        [SerializeField] 
        [Required] 
        private NavMeshAgent navMeshAgent;
        
        [SerializeField] 
        [Required] 
        private ActorHealth actorHealth;
        
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

        private bool _isTargetDetected = false;
        private bool _isTargetInAttackRange = false;
       
        // -------- 
        public EnemyData Data => data;
        public NavMeshAgent NavMeshAgent => navMeshAgent;

        public bool IsTargetDetected => _isTargetDetected;

        public bool IsTargetInAttackRange => _isTargetInAttackRange;

        private void Awake()
        {
            detectionTrigger.OnEnter -= DetectTarget;
            detectionTrigger.OnEnter += DetectTarget;
            
            detectionTrigger.OnExit -= UnDetectTarget;
            detectionTrigger.OnExit+= UnDetectTarget;
            
            attackTrigger.OnEnter -= DetectAttackTarget;
            attackTrigger.OnEnter += DetectAttackTarget;
            
            attackTrigger.OnExit -= UnDetectAttackTarget;
            attackTrigger.OnExit+= UnDetectAttackTarget;
        }

        private void Start()
        {
            actorHealth.InitHealth(data.MaxHealth); 
            detectionZone.radius = data.ChaseDetectionRange;
            attackZone.radius = data.AttackDetectionRange;

        }

        private void OnDestroy()
        {
            detectionTrigger.OnEnter -= DetectTarget;
            detectionTrigger.OnExit -= UnDetectTarget;
            
            attackTrigger.OnEnter -= DetectAttackTarget;
            attackTrigger.OnExit -= UnDetectAttackTarget;
        }
        //todo write it better
        private void DetectTarget()
        {
            _isTargetDetected = true;
        }
        private void UnDetectTarget()
        {
            _isTargetDetected = false; 
        }
        private void DetectAttackTarget()
        {
            _isTargetInAttackRange = true;
        }
        private void UnDetectAttackTarget()
        {
            _isTargetInAttackRange = false;
        }
    }
}