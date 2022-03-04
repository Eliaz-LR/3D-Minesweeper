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
            SaveScore();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    private void ReturnToMenuField(string oui)
    {
        ReturnToMenuButton();
    }
    private void SaveScore()
    {
        Score score=new Score(GameObject.Find("Timer").GetComponent<Timer>().time);
        CompareWithDatabase(score);
    }
    private void PushToDatabase(Score score)
    {
        RestClient.Put("https://demineur-3d-default-rtdb.europe-west1.firebasedatabase.app/"+DifficultyGrid.difficulty+"/"+pseudoField.text+".json",score);
    }
    private void CompareWithDatabase(Score score)
    {
        RestClient.Get<Score>("https://demineur-3d-default-rtdb.europe-west1.firebasedatabase.app/"+DifficultyGrid.difficulty+"/"+pseudoField.text+".json").Then(response =>
        {
            if (score.time<response.time)
            {
                PushToDatabase(score);
            }
        });
    }
}
