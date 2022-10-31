using UnityEngine;

namespace Candy.Enemy.Logic.Base
{
#if UNITY_EDITOR
    [CreateAssetMenu(menuName = "Enemy/State/Debug")]
    public sealed class DebugState : StateBase
    {

        [SerializeField] private string startingLine;
        [SerializeField] private string tickLine;
        [SerializeField] private string finishingLine;
        protected override void ActonOnStart(EnemyActor enemy)
        {
             Debug.Log(startingLine);
        }

        protected override void ActOnTick(EnemyActor enemy)
        {
            Debug.Log(tickLine);
        }

        protected override void ActonOnFinish(EnemyActor enemy)
        {
            Debug.Log(finishingLine);
        }
    }
#endif
}