using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Candy.Menu
{
    public sealed class MainMenuService : MonoBehaviour, IMenuService
    {
        [SerializeField] private Slider sensitivityXSlider;
        [SerializeField] private Slider sensitivityYSlider;
        [SerializeField] private Slider soundSlider;

        [SerializeField] private Button startButton;
        [SerializeField] private Button quitButton;
        
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
            SaveSlidersValue();
            OnGameStart?.Invoke();
        }
        
        public void QuitGame()
        {
            SaveSlidersValue();
            OnApplicationQuite?.Invoke();
            Application.Quit();
        }
        private void InitSliders()
        {
            var sensY = PlayerPrefs.GetFloat("sensitivityY", sensitivityYSlider.maxValue / 2);
            var sensX = PlayerPrefs.GetFloat("sensitivityX", sensitivityXSlider.maxValue / 2);
            var audio = PlayerPrefs.GetFloat("audio", soundSlider.maxValue / 2);

            sensitivityYSlider.value = sensY;
            sensitivityXSlider.value = sensX;
            soundSlider.value = audio;
        }

        private void SaveSlidersValue()
        {
            PlayerPrefs.SetFloat("sensitivityY",sensitivityYSlider.value);
            PlayerPrefs.SetFloat("sensitivityX",sensitivityXSlider.value);
            PlayerPrefs.SetFloat("audio",soundSlider.value);
            PlayerPrefs.Save();
        }
   
    }
}