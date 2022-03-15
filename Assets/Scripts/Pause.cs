using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public void PauseToggle()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            // permet de checker que le jeu n'est pas deja en pause a cause d'une victoire ou d'une defaite
            if (Time.timeScale != 0f)
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ReturnToMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
