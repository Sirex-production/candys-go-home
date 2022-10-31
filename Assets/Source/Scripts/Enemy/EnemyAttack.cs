using System.Collections;
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
            yield return new WaitForSeconds(2);
            _attackCoroutine = null;
        }
        
        private IEnumerator PerformRangeAttackCoroutine()
        {
            yield return new WaitForSeconds(2);
            _attackCoroutine = null;
        }
    }
}