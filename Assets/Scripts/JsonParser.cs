using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonParser
{
    public static Highscore[] Parse(string toParse)
    {
        
        toParse = toParse.Substring(1, toParse.Length - 2);
        string[] scores = toParse.Split(',');
        Debug.Log(scores[0]);
        Highscore[] highscores = new Highscore[scores.Length+1];
        for (int i = 0; i < scores.Length; i++)
        {
            //"Eliaz":{"time":44.39243698120117}
            var charToRemove = new char[] { '\"', '{', '}' };
            foreach (var c in charToRemove)
            {
                scores[i] = scores[i].Replace(c.ToString(), "");
            }
            string[] score = scores[i].Split(new string[] {":time:"}, System.StringSplitOptions.None);
            highscores[i] = new Highscore(score[0], float.Parse(score[1], System.Globalization.CultureInfo.InvariantCulture));
        }

        return highscores;
    }
}
