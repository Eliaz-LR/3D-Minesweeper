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
            // Debug.Log(json);
            Highscore[] highscores = JsonParser.Parse(json);
            // Debug.Log(highscores);
        }).Catch(err => Debug.LogError(err.Message));
    }

}
