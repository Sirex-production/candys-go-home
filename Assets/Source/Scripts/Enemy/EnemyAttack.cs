using System.Collections;
using Candy.Actors;
using Candy.Player;
using Candy.Projectile;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Candy.Enemy
{
    public sealed class EnemyAttack : MonoBehaviour
    {
        [SerializeField] 
        [Required]
        private EnemyActor enemyActor;

        private IProjectileService _projectileService;
        private Coroutine _attackCoroutine;
        private bool _isAlreadyUsed = false;
        
        [Inject]
        private void Construct( IProjectileService projectileService)
        {
            _projectileService = projectileService;
        }
        
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
        
        private IEnumerator PerformMeleeAttackCoroutine()
        {
            yield return new WaitForSeconds(enemyActor.Config.AttackSpeed);
            Collider[] hitColliders = new Collider[1];
            int amountOfHitColliders = Physics.OverlapSphereNonAlloc(transform.position, enemyActor.Config.AttackRange,hitColliders, LayerMask.GetMask("Player"), QueryTriggerInteraction.Collide);
            if (amountOfHitColliders>0 && enemyActor.target.root.TryGetComponent<PlayerService>(out var player))
            {
                player.TakeDamage(enemyActor.Config.Damage);
            }
            
            yield return new WaitForSeconds(enemyActor.Config.AttackInterval);
            _attackCoroutine = null;
        }
        
        private IEnumerator PerformRangeAttackCoroutine()
        {
            yield return new WaitForSeconds(enemyActor.Config.AttackSpeed);
            _projectileService.SpawnProjectile(0, transform.position, transform.forward ,false);
            yield return new WaitForSeconds(enemyActor.Config.AttackInterval);
            _attackCoroutine = null;
        }
    }
}