using Candy.Enemy.Logic.Base;
using UnityEngine;

namespace Candy.Enemy.Logic.States
{
    [CreateAssetMenu(menuName = "Enemy/State/Idle")]
    public sealed class IdleState : StateBase
    {
        protected override void ActonOnStart(EnemyActor enemy)
        {
            enemy.NavMeshAgent.isStopped = true;
        }

        protected override void ActOnTick(EnemyActor enemy)
        {
            
        }

        protected override void ActonOnFinish(EnemyActor enemy)
        {
            
        }
    }
}