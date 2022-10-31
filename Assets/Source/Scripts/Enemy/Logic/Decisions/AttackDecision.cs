using Candy.Enemy.Logic.Base;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace Candy.Enemy.Logic.Decisions
{
    [CreateAssetMenu(menuName = "Enemy/Decision/Attack")]
    public sealed class AttackDecision : DecisionBase
    {
        [SerializeField]
        private LayerMask ignoredMask;
        public override bool ShouldChangeState(EnemyActor enemy)
        {
            return enemy.IsTargetInAttackRange;
            /*if (!enemy.IsTargetInAttackRange)
            {
                return false;
            }
            return  !Physics.Linecast(enemy.transform.position, enemy.target.position, ignoredMask, QueryTriggerInteraction.Ignore);    */
        }
        
    }
}