using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public static class JsonParser
{
    public static Highscore[] Parse(string toParse)
    {
        JSONNode data = JSON.Parse(toParse);
        Highscore[] highscores = new Highscore[data.Count];
        Debug.Log(highscores.Length);
        for (int i = 0; i < data.Count; i++)
        {
            highscores[i] = new Highscore();
            Debug.Log(data[i].Children.GetEnumerator().Current.Value);
            // highscores[i].time = data[i].Children[0].AsFloat;
            // highscores[i].name = data[i].Value;
        }
        
        return highscores;
    }
}
