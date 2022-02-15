using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager
{
    public GameObject[,] squareObjectCollection { get; set; }
    private List<Vector2Int> emplacementsMines;

    public ParticleManager(GameObject[,] squareObjectCollection, List<Vector2Int> emplacementsMines)
    {
        this.squareObjectCollection = squareObjectCollection;
        this.emplacementsMines = emplacementsMines;
    }

    void ParticuleGameOver()
    {
        foreach (emplacementsMines)
        {
            squareObjectCollection[emplacementsMines.x,emplacementsMines.y]
        }
    }

    void ParticuleWin()
    {

    }

  
}
