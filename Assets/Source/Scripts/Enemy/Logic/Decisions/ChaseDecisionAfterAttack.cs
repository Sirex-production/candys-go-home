using Candy.Enemy.Logic.Base;
using UnityEngine;

namespace Candy.Enemy.Logic.Decisions
{
    [CreateAssetMenu(menuName = "Enemy/Decision/ChaseAfterAttack")]
    public class ChaseDecisionAfterAttack : DecisionBase
    {
        public override bool ShouldChangeState(EnemyActor enemy)
        {
            return !enemy.IsTargetInAttackRange;
        }
    }
}