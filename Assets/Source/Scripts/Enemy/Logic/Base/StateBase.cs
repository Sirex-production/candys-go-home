using System.Collections.Generic;
using UnityEngine;

namespace Candy.Enemy.Logic.Base
{
    public abstract class StateBase : ScriptableObject
    {
#if UNITY_EDITOR
        [SerializeField] private Color color;
#endif
        [SerializeField] 
        private List<DecisionBase> decisions;
        [SerializeField]
        private bool isRestartable = false;
        [SerializeField]
        protected bool isActionBlockable = false;
        protected abstract void ActonOnStart(EnemyActor enemy);
        protected abstract void ActOnTick(EnemyActor enemy);
        protected abstract void ActonOnFinish(EnemyActor enemy);
        
        private Dictionary<EnemyActor, bool> _enemiesStateVisiting = new();
        
        protected virtual bool CheckIfBlocked(EnemyActor enemyActor)
        {
            return false;
        }
        public StateBase Tick(EnemyActor enemy)
        {
            //OnStart
            if (!_enemiesStateVisiting.ContainsKey(enemy))
            {
                _enemiesStateVisiting.Add(enemy,false);
            }
            if ( !_enemiesStateVisiting[enemy])
            {
                ActonOnStart(enemy);
                _enemiesStateVisiting[enemy] = true;
#if UNITY_EDITOR
                enemy.GetComponent<Renderer>().material.color = new Color(color.r,color.g,color.b,1);
#endif
            }
            
            ActOnTick(enemy);
            //blocking
            if (isActionBlockable && CheckIfBlocked(enemy))
            {
                return this;
            }
            //decide to change a state
            for (int i = 0; i < decisions.Count; i++)
            {
                if (decisions[i].ShouldChangeState(enemy)) 
                {
                    _enemiesStateVisiting[enemy] = false;
                    ActonOnFinish(enemy);
                    return decisions[i].NextState;
                }
            }
            //restart state
            if (isRestartable)
            {
                ResetState(enemy);
            }
            return this;
        }

        public void ResetState(EnemyActor enemyActor)
        {
            ActonOnStart(enemyActor);
        }
        
        
    }
}