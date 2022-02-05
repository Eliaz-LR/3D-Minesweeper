using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweeperGenerator
{
    private Vector2Int size;
    private int nbMines;
    private List<Vector2Int> emplacementsMines;
    private SweeperManager sweeperManager;
    public SweeperGenerator(Vector2Int size, int numberOfMines, SweeperManager sweeperManager)
    {
        this.size = size;
        this.nbMines = numberOfMines;
        this.sweeperManager = sweeperManager;
    }

    public List<Vector2Int> Generate(Vector2Int coordInitClick)
    {
        emplacementsMines=new List<Vector2Int>();
        int randX;
        int randY;
        for (int i = 0; i < nbMines-1; i++)
        {
            do
            {
                randX=Random.Range(0,size.x);
                randY=Random.Range(0,size.y);
            } while ((!CaseIsFree(randX,randY,coordInitClick))||(ClickAround(coordInitClick,randX,randY)) );
            emplacementsMines.Add(new Vector2Int(randX,randY));
        }
        Debug.Log(emplacementsMines);
        return emplacementsMines;
    }

    private bool ClickAround(Vector2Int coordInitClick, int mineX, int mineY)
    {
        List<Vector2Int> neighbouringClick;
        neighbouringClick=sweeperManager.GetNeighbouringCoords(coordInitClick);
        if (neighbouringClick.Contains(new Vector2Int(mineX,mineY)))
        {
            return true;
        }
        return false;
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