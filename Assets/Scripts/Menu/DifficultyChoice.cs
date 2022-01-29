using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyChoice : MonoBehaviour
{
    public void Easy()
    {
        DifficultyGrid.setSize(8,8);
        PlayGame();
    }
    public void Medium()
    {
        DifficultyGrid.setSize(15,15);
        PlayGame();
    }
    public void Hard()
    {
        DifficultyGrid.setSize(21,21);
        PlayGame();
    }
    private void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
