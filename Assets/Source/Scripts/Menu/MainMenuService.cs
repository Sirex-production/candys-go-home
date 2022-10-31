using System;
using System.Collections;
using System.Collections.Generic;
using Support;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Candy.Menu
{
    public sealed class MainMenuService : MonoBehaviour, IMenuService
    {
        [SerializeField] private Slider sensitivitySlider;
        [SerializeField] private Slider soundSlider;

        [SerializeField] private Button startButton;
        [SerializeField] private Button quitButton;
        
        private LevelManagementService _levelManagementService;

        private float _minSensitivity =0.01f;
        private float _maxSensitivity = 2;
        [Inject]
        private void Construct(LevelManagementService levelManagementService)
        {
            _levelManagementService = levelManagementService;
        }
        
        
        public event Action OnGameStart;
        public event Action OnApplicationQuite;
        
        private void Start()
        {
            InitSliders();
            startButton.onClick.AddListener(StartGame);
            quitButton.onClick.AddListener(QuitGame);
        }
        
        public void StartGame()
        {
            sensitivitySlider.maxValue = _maxSensitivity;
            sensitivitySlider.minValue = _minSensitivity;
            SaveSlidersValue();
            OnGameStart?.Invoke();
            _levelManagementService.LoadLevel(1);
        }
        
        public void QuitGame()
        {
            SaveSlidersValue();
            OnApplicationQuite?.Invoke();
            Application.Quit();
        }
        private void InitSliders()
        {
            var sens = PlayerPrefs.GetFloat("sensitivity", sensitivitySlider.maxValue / 2);
            var audio = PlayerPrefs.GetFloat("audio", soundSlider.maxValue / 2);

            sensitivitySlider.value = sens;
            soundSlider.value = audio;
        }

        private void SaveSlidersValue()
        {
            PlayerPrefs.SetFloat("sensitivity",sensitivitySlider.value);
            PlayerPrefs.SetFloat("audio",soundSlider.value);
            PlayerPrefs.Save();
        }
   
    }
}