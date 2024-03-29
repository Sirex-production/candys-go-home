﻿using System;
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
        private EnemyActor actor;
        
        [SerializeField]
        [Required]
        private StateBase startingState;
        
        private StateBase _currentState;

        private void Start()
        {
            _currentState = startingState;
        }
        
        private void FixedUpdate()
        {
            _currentState = _currentState.Tick(actor);
        }

        public void ResetBehaviour()
        {
            _currentState = startingState;
        }
    }

}