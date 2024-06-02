using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SurvivalAtUSV
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] GameObject pauseMenu;

        public void Pause() 
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        public void Home()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        public void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
