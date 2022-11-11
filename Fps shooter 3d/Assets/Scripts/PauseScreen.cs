using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public Gun gunScript;

    public static bool gameIsPaused;

    public GameObject pauseMenuUI;
    //public GameObject gameOverMenu;
    //public GameObject mainMenuUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        Debug.Log("Game resumed");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        gunScript.enabled = true;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

        Debug.Log("Game is paused");

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        gunScript.enabled = false;
    }

    public void Quit()
    {
        Application.Quit();

        Debug.Log("Game Quit");
    }

    public void Menu()
    {
        Debug.Log("Menu screen");
    }
}
