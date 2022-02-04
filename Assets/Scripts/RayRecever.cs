using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRecever : MonoBehaviour
{

    public Material reaveled;
    private Vector2Int coord;

    public void setCoord(Vector2Int coord)
    {
        this.coord = coord;
    }
    public void Activate()
    {
        Debug.Log("activation du cube " + coord);
        GetComponent<Renderer>().material = reaveled;
    }
}
