using System;
using System.Collections.Generic;
using Candy.Enemy.Logic.Base;
using NaughtyAttributes;
using UnityEngine;

namespace Candy.Enemy
{
    public sealed class BehaviorAgent : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private StateBase currentState;

        
        
        private void Update()
        {
            //currentState = currentState.Tick();
        }
    }

}