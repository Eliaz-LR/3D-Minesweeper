using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyChoice : MonoBehaviour
{
    public void Easy()
    {
        DifficultyGrid.setSize(8,8);
        DifficultyGrid.nbMines = 10;
        DifficultyGrid.difficulty='e';
        PlayGame();
    }
    public void Medium()
    {
        DifficultyGrid.setSize(15,15);
        DifficultyGrid.nbMines = 40;
        DifficultyGrid.difficulty='m';
        PlayGame();
    }
    public void Hard()
    {
        DifficultyGrid.setSize(21,21);
        DifficultyGrid.nbMines = 99;
        DifficultyGrid.difficulty='h';
        PlayGame();
    }
    private void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
