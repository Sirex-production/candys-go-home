using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Support
{
    /// <summary>
    /// Class that manages levels
    /// </summary>
    public sealed class LevelManagementService : MonoBehaviour
    {
        /// <summary>
        /// Loads level
        /// </summary>
        /// <param name="sceneIndex">Level index that will be loaded</param>
        /// <exception cref="ArgumentException"></exception>
        public void LoadLevel(int sceneIndex)
        {
            if (sceneIndex < 0)
                throw new ArgumentException($"There is no level with such index \"{sceneIndex}\"");

            SceneManager.LoadScene(sceneIndex);
        }

        /// <summary>Restarts last level that was saved in progress(SaveLoadSystem)</summary>
        public void RestartLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}