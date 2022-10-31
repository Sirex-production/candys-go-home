using Candy.Enemy.Logic.Base;
using UnityEngine;

namespace Candy.Enemy.Logic.Decisions
{
    [CreateAssetMenu(menuName = "Enemy/Decision/Attack")]
    public sealed class AttackDecision : DecisionBase
    {
  
        public override bool ShouldChangeState(EnemyActor enemy)
        {
            return enemy.IsTargetDetected && enemy.IsTargetInAttackRange;
        }
    }
}