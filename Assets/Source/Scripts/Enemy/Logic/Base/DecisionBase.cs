using NaughtyAttributes;
using UnityEngine;

namespace Candy.Enemy.Logic.Base
{
    public abstract class DecisionBase : ScriptableObject
    {
        [SerializeField]
        [Required]
        private StateBase nextState;
        public StateBase NextState => nextState;

        public abstract bool ShouldChangeState(EnemyActor enemy);
    }
}