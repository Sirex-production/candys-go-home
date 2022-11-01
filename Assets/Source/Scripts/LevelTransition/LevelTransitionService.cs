using System;
using System.Collections;
using Candy.Wave;
using Support;
using UnityEngine;
using Zenject;

namespace Candy.LevelTransition
{
    public class LevelTransitionService : MonoBehaviour , ILevelTransitionService
    {
        [SerializeField] 
        private int nextSceneId;

        [SerializeField] private WaveService waveService;
        private LevelManagementService _levelManagementService;
      
        [Inject]
        private void Construct(LevelManagementService levelManagementService)
        {
            _levelManagementService = levelManagementService;
            
        }
        
        private void Awake()
        {
            waveService.OnStageFinish += FinishLevel;
        }

        private void FinishLevel()
        {
            _levelManagementService.LoadLevel(nextSceneId);
        }

        IEnumerator FinishLevelCoroutine()
        {
            yield break;
           
            
        }
    }
}