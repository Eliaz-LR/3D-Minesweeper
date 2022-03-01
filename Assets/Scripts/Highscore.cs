using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore
{
    public float time;
    public string name;
    public int rank;
    public Highscore(string name, float time)
    {
        this.name = name;
        this.time = time;
    }
}
