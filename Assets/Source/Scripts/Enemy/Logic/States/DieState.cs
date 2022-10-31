using Candy.Enemy.Logic.Base;
using UnityEngine;

namespace Candy.Enemy.Logic.States
{
    [CreateAssetMenu(menuName = "Enemy/State/Die")]
    public sealed class DieState : StateBase
    {
       
        protected override void ActonOnStart(EnemyActor enemy)
        {
            enemy.TimeToDie = enemy.Config.TimeToDie;
        }

        protected override void ActOnTick(EnemyActor enemy)
        {
            enemy.EnemyAnimator.PlayDie();
            enemy.TimeToDie -= Time.deltaTime;
            if (enemy.TimeToDie <= 0) 
            {
                enemy.ReleaseToPool(0);
            }
        }

        protected override void ActonOnFinish(EnemyActor enemy)
        {
            
        }
    }
}