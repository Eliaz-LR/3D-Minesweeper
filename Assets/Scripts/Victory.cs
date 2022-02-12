using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Proyecto26;

public class Victory : MonoBehaviour
{
    public Button menuButton;
    public TMP_InputField pseudoField;
    public void Setup(){
        gameObject.SetActive(true);
        menuButton.onClick.AddListener(ReturnToMenuButton);
        pseudoField.onSubmit.AddListener(ReturnToMenuField);
    }
    public void ReturnToMenuButton()
    {
        if (pseudoField.text!="")
        {
            SaveScoreToDatabase();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    private void ReturnToMenuField(string oui)
    {
        ReturnToMenuButton();
    }
    private void SaveScoreToDatabase()
    {
        Score score=new Score(DifficultyGrid.difficulty,pseudoField.text,GameObject.Find("Timer").GetComponent<Timer>().time);
        Debug.Log(score.username);
        RestClient.Post("https://demineur-3d-default-rtdb.europe-west1.firebasedatabase.app/.json",score);
    }
}
