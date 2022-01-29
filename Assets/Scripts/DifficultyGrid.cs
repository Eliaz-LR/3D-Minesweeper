using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyGrid
{
    private static Vector2 vector2;
    public static Vector2 getSize()
    {
        return vector2;
    }
    public static void setSize(int x, int y)
    {
        vector2.Set(x,y);
    }
}
