using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameOver gameOver;
    public Victory victory;
    public void GameOver()
    {
        MenuSetup();
        gameOver.Setup();
    }
    public void Victory()
    {
        MenuSetup();
        victory.Setup();
    }
    private void MenuSetup()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
    private void MenuQuit()
    {

    }
}
