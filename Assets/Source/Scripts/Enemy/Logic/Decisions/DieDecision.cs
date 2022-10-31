using Candy.Enemy.Logic.Base;
using UnityEngine;

namespace Candy.Enemy.Logic.Decisions
{
    [CreateAssetMenu(menuName = "Enemy/Decision/Die")]
    public sealed class DieDecision : DecisionBase
    {
        public override bool ShouldChangeState(EnemyActor enemy)
        {
            return enemy.IsDead;
        }
    }
}