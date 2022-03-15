using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public void PauseKey(InputAction.CallbackContext context)
    {
        if (context.performed)
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
    }

    private void PauseGame()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
