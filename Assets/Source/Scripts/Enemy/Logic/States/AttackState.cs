using Candy.Enemy.Logic.Base;
using Candy.Projectile;
using UnityEngine;
using Zenject;

namespace Candy.Enemy.Logic.States
{
    [CreateAssetMenu(menuName = "Enemy/State/Attack")]
    public sealed class AttackState : StateBase
    {
        
        
        protected override void ActonOnStart(EnemyActor enemy)
        {
            enemy.EnemyAttack.IsAlreadyUsed = false;
            enemy.LockOnTarget();
        }

        protected override void ActOnTick(EnemyActor enemy)
        {

        
            if (enemy.EnemyAttack.IsAlreadyUsed)
            {
                return;
            }
            enemy.EnemyAnimator.PlayAttack();
            enemy.EnemyAttack.Attack();
        }

        protected override void ActonOnFinish(EnemyActor enemy)
        {
             
        }

        protected override bool CheckIfBlocked(EnemyActor enemyActor)
        {
            if (enemyActor.IsDead)
            {
                return false;
            }
            return enemyActor.EnemyAttack.IsAttackActionRunning();
        }
    }
}