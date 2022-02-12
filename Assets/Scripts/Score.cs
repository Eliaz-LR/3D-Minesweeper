using System;

[Serializable]
public class Score
{
    public char difficulty; //e,m,h
    public string username;
    public float time; //time in seconds
    public Score(char difficulty,string username,float time)
    {
        this.difficulty=difficulty;
        this.username=username;
        this.time=time;
    }
}
