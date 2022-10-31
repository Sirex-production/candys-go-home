using System.Collections.Generic;
using UnityEngine;

namespace Candy.Enemy.Logic.Base
{
    public abstract class StateBase : ScriptableObject
    {

        
        [SerializeField] 
        private List<DecisionBase> decisions;
        protected abstract void ActonOnStart(EnemyActor enemy);
        protected abstract void ActOnTick(EnemyActor enemy);
        protected abstract void ActonOnFinish(EnemyActor enemy);

        private Dictionary<EnemyActor, bool> _enemiesStateVisiting = new(); 
        
        public StateBase Tick(EnemyActor enemy)
        {
            if (!_enemiesStateVisiting.ContainsKey(enemy))
            {
                _enemiesStateVisiting.Add(enemy,false);
            }
            if ( !_enemiesStateVisiting[enemy])
            {
                ActonOnStart(enemy);
                _enemiesStateVisiting[enemy] = true;
            }
            
            ActOnTick(enemy);
            for (int i = 0; i < decisions.Count; i++)
            {
                if (!decisions[i].ShouldChangeState(enemy)) continue;

                _enemiesStateVisiting[enemy] = false;
                ActonOnFinish(enemy);
                return decisions[i].NextState;

            }

            return this;
        }
    }
}