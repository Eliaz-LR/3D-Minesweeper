using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using TMPro;
using System.Threading;

public class HighscoresMenu : MonoBehaviour
{
    public TMP_Dropdown difficulty;
    private Transform entryTemplate;
    private string json;

    private void Awake()
    {
        entryTemplate = transform.Find("HighscoreEntryTemplate");
        RetriveFromDatabase("easy");
    }
    private void RetriveFromDatabase(string difficulty)
    {
        RestClient.Get("https://demineur-3d-default-rtdb.europe-west1.firebasedatabase.app/" + difficulty + ".json").Then(response =>
        {
            json = response.Text;
            //Highscore[] highscores = JsonParser.Parse(json);
        }).Catch(err => Debug.LogError(err.Message));
    }

    // private IEnumerator RetriveFromDatabase(string difficulty)
    // {
    //     var running = true;
    //     RestClient.Get("https://demineur-3d-default-rtdb.europe-west1.firebasedatabase.app/" + difficulty + ".json").Then(response =>
    //     {
    //         json = response.Text;
    //         running = false;
    //     }).Catch(err => Debug.LogError(err.Message));

    //     Debug.Log("Waiting...");
    //     while (running)
    //     {
    //         yield return new WaitForSeconds(0.01f);
    //     }
    //     Debug.Log("Done!");
    //     Debug.Log(json);
    // }
}
