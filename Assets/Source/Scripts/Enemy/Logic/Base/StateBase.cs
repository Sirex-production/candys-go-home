using System.Collections.Generic;
using UnityEngine;

namespace Candy.Enemy.Logic.Base
{
    public abstract class StateBase : ScriptableObject
    {

        [SerializeField] 
        private List<DecisionBase> decisions;
        protected abstract void ActonOnStart(Darek enemy);
        protected abstract void ActOnTick(Darek enemy);
        protected abstract void ActonOnFinish(Darek enemy);

        private Dictionary<Darek, bool> _enemiesStateVisiting = new(); 
        public StateBase Tick(Darek enemy)
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