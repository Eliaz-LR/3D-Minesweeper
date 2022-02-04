using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyGrid
{
    private static Vector2Int position;
    public static int nbMines{get;set;}
    public static Vector2Int getSize()
    {
        return position;
    }
    public static void setSize(int x, int y)
    {
        position.Set(x,y);
    }
}
