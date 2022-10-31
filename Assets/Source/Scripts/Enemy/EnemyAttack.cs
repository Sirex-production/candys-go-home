﻿using System.Collections;
using Candy.Actors;
using NaughtyAttributes;
using UnityEngine;

namespace Candy.Enemy
{
    public sealed class EnemyAttack : MonoBehaviour
    {
        [SerializeField] 
        [Required]
        private EnemyActor enemyActor;
        private Coroutine _attackCoroutine;
        private bool _isAlreadyUsed = false;
        
        public bool IsAlreadyUsed
        {
            get => _isAlreadyUsed;
            set => _isAlreadyUsed = value;
        }

        public bool IsAttackActionRunning()
        {
            return _attackCoroutine != null;
        }
        
        public void Attack()
        {
            if (_attackCoroutine != null)
            {
                return;
            }
            _isAlreadyUsed = true;
            _attackCoroutine = StartCoroutine(
                (enemyActor.Config.TypeOfAttack == TypeOfAttack.Melee ? 
                    PerformMeleeAttackCoroutine() : 
                    PerformRangeAttackCoroutine()));
        }
        
        //todo fill attack script
        private IEnumerator PerformMeleeAttackCoroutine()
        {
            yield return new WaitForSeconds(enemyActor.Config.AttackSpeed);
            Collider[] hitColliders = new Collider[1];
            int amountOfHitColliders = Physics.OverlapSphereNonAlloc(transform.position, enemyActor.Config.AttackRange,hitColliders, LayerMask.GetMask("Player"), QueryTriggerInteraction.Collide);
            if (amountOfHitColliders>0 && enemyActor.target.root.TryGetComponent<ActorHealth>(out var playerHealth))
            {
                playerHealth.TakeDamage(enemyActor.Config.Damage);
            }
            yield return new WaitForSeconds(enemyActor.Config.AttackInterval);
            _attackCoroutine = null;
        }
        
        private IEnumerator PerformRangeAttackCoroutine()
        {
            yield return new WaitForSeconds(2);
            _attackCoroutine = null;
        }
    }
}