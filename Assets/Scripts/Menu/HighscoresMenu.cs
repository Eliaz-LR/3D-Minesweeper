using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using TMPro;
using System.Linq;
using System.Threading;
using System;

public class HighscoresMenu : MonoBehaviour
{
    public TMP_Dropdown difficulty;
    private Transform entryTemplate;
    private string json;

    private void Awake()
    {
        entryTemplate = transform.Find("HighscoreEntryTemplate");
        difficulty.onValueChanged.AddListener(delegate {
            StartCoroutine(GetHighscores());
        });
        RetriveFromDatabase("easy");
    }
    private IEnumerator GetHighscores()
    {
        string difficulty = this.difficulty.options[this.difficulty.value].text;
        RetriveFromDatabase(difficulty);
        yield return null;
    }
    private void RetriveFromDatabase(string difficulty)
    {
        RestClient.Get("https://demineur-3d-default-rtdb.europe-west1.firebasedatabase.app/" + difficulty + ".json").Then(response =>
        {
            json = response.Text;
            // Debug.Log(json);
            Highscore[] highscores = JsonParser.Parse(json);
            highscores = AddRank(highscores);
            DisplayHighscores(highscores);
            //Debug.Log(highscores);
        }).Catch(err => Debug.LogError(err.Message));
    }
    private Highscore[] AddRank(Highscore[] highscores)
    {
        IEnumerable<Highscore> sorted = highscores.OrderBy(x => x.time);
        int rank = 1;
        foreach (Highscore h in sorted)
        {
            h.rank = rank;
            rank++;
        }
        return highscores;
    }
    private void DisplayHighscores(Highscore[] highscores)
    {
        foreach (Transform child in transform)
        {
            if (child != entryTemplate)
            {
                Destroy(child.gameObject);
            }
        }
        foreach (Highscore highscore in highscores)
        {
            Transform entryTransform = Instantiate(entryTemplate, transform);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -50 * highscore.rank -50);
            entryTransform.Find("Position").GetComponent<TextMeshProUGUI>().text = highscore.rank.ToString();
            entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = highscore.name;
            entryTransform.Find("Time").GetComponent<TextMeshProUGUI>().text = TimeSpan.FromSeconds(highscore.time).ToString(@"mm\:ss\.ff");
        }
    }

}
