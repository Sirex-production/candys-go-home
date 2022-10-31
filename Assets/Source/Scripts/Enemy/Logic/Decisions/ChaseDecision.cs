using System;
using Candy.Enemy.Logic.Base;
using UnityEngine;

namespace Candy.Enemy.Logic.Decisions
{
    [CreateAssetMenu(menuName = "Enemy/Decision/Chase")]
    public sealed class ChaseDecision : DecisionBase
    {
        [SerializeField]
        private LayerMask ignoredMask;
        public override bool ShouldChangeState(EnemyActor enemy)
        {
            var decision = enemy.IsTargetDetected() && !enemy.IsTargetInAttackRange;
            return decision;
            /*if (!decision)
            {
                return false;
            }
            return  !Physics.Linecast(enemy.transform.position, enemy.target.position, ignoredMask, QueryTriggerInteraction.Ignore);    */

        }
    }
}