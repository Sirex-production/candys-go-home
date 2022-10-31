using System;
using Candy.Enemy.Logic.Base;
using UnityEngine;

namespace Candy.Enemy.Logic.Decisions
{
    [CreateAssetMenu(menuName = "Enemy/Decision/Chase")]
    public sealed class ChaseDecision : DecisionBase
    {
        public override bool ShouldChangeState(EnemyActor enemy)
        {
            return enemy.IsTargetDetected() && !enemy.IsTargetInAttackRange;
        }
    }
}