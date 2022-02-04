using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweeperManager
{
    private Vector2Int size;
    private int nbMines;
    private List<Vector2Int> emplacementsMines;
    SweeperGenerator sweeperGenerator=null;
    SweeperManager(Vector2Int size, int nbMines)
    {
        this.size = size;
        this.nbMines = nbMines;
    }
    public void activate(Vector2Int coords)
    {
        if (sweeperGenerator==null)
        {
            sweeperGenerator=new SweeperGenerator(size,nbMines);
            emplacementsMines=sweeperGenerator.Generate(coords);
        }
        
    }
}
