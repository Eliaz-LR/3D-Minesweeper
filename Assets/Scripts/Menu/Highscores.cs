using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class Highscores : MonoBehaviour
{
    public TMP_Dropdown difficulty;
    private Transform entryTemplate;
    private string json;

    private void Awake()
    {
        entryTemplate = transform.Find("HighscoreEntryTemplate");
        Debug.Log(RetriveFromDatabase("easy"));
    }
    private IEnumerable RetriveFromDatabase(string difficulty)
    {
        string URL="https://demineur-3d-default-rtdb.europe-west1.firebasedatabase.app/";
        UnityWebRequest scoreInfoRequest = UnityWebRequest.Get(URL+difficulty+".json");

        yield return scoreInfoRequest.SendWebRequest();

        if (scoreInfoRequest.result == UnityWebRequest.Result.ConnectionError || scoreInfoRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(scoreInfoRequest.error);
            yield break;
        }
        json = scoreInfoRequest.downloadHandler.text;
        Debug.Log(json);
    }
}
