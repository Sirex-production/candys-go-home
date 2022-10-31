using Candy.Enemy.Logic.Base;
using UnityEngine;

namespace Candy.Enemy.Logic.States
{
    [CreateAssetMenu(menuName = "Enemy/State/Chase")]
    public sealed class ChaseState : StateBase
    {
        protected override void ActonOnStart(EnemyActor enemy)
        {
             
        }

        protected override void ActOnTick(EnemyActor enemy)
        {
            enemy.EnemyAnimator.PlayWalk();
            var navAgent = enemy.NavMeshAgent;
            navAgent.SetDestination(enemy.target.position);
            navAgent.speed = enemy.Config.MovementSpeed;
            navAgent.isStopped = false;
            
        }

        protected override void ActonOnFinish(EnemyActor enemy)
        {
            enemy.NavMeshAgent.isStopped = true;
        }
    }
}