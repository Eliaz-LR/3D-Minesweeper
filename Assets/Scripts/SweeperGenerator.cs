using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweeperGenerator
{
    private Vector2Int size;
    private int nbMines;
    private List<Vector2Int> emplacementsMines;
    public SweeperGenerator(Vector2Int size, int numberOfMines)
    {
        this.size = size;
        this.nbMines = numberOfMines;
    }

    public List<Vector2Int> Generate(Vector2Int coordInitClick)
    {
        emplacementsMines=new List<Vector2Int>();
        int randX;
        int randY;
        for (int i = 0; i < nbMines; i++)
        {
            do
            {
                randX=Random.Range(0,size.x);
                randY=Random.Range(0,size.y);
            } while (!CaseIsFree(randX,randY,coordInitClick));
            emplacementsMines.Add(new Vector2Int(randX,randY));
        }
        return emplacementsMines;
    }

    private bool CaseIsFree(int randX, int randY, Vector2Int coordInitClick){
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