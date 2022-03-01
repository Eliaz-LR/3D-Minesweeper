using System;

[Serializable]
public class Score
{
    public float time; //time in seconds
    public string pseudo;
    public Score(float time, string pseudo = "")
    {
        this.time = time;
        this.pseudo = pseudo;
    }
}
