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
        //private WaveService _waveService;
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
            
            Debug.Log(1);
            _levelManagementService.LoadLevel(nextSceneId);
            //StartCoroutine(FinishLevelCoroutine());
        }

        IEnumerator FinishLevelCoroutine()
        {
            yield break;
           
            //_levelManagementService.LoadLevel(nextSceneId);
        }
    }
}