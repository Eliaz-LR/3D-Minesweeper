using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSweeperGrid
{
    private static MineSweeperGrid _instance;
    static readonly object instanceLock = new object();
    private Vector2Int size;
    private MineSweeperGrid(Vector2Int size)
    {
        this.size = size;
    }
    public static MineSweeperGrid Instance
    {
        get
        {
            if (_instance == null) 
            {
                Debug.LogError("MineSweeperGrid is null");
            }
            return _instance;
        }
    }

    public void Generate(int numberOfMines,Vector2Int coordInitClick)
    {
        List<Vector2Int> emplacementsMines=new List<Vector2Int>();
        int randX;
        int randY;
        for (int i = 0; i < numberOfMines; i++)
        {
            do
            {
                randX=Random.Range(0,size.x);
                randY=Random.Range(0,size.y);
            } while (!caseIsFree(randX,randY,coordInitClick,emplacementsMines));
            emplacementsMines.Add(new Vector2Int(randX,randY));
        }
    }

    private bool caseIsFree(int randX, int randY, Vector2Int coordInitClick, List<Vector2Int> emplacementsMines){
        Vector2Int rand = new Vector2Int(randX,randY);
        if (coordInitClick==rand)
        {
            return false;
        }
        else if (emplacementsMines.Contains(rand))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}