using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRecever : MonoBehaviour
{

    public Material reaveled;
    private Vector2Int coord;
    public bool activated=false;


    public void setCoord(Vector2Int coord)
    {
        this.coord = coord;
    }
    public void Activate()
    {
        if (activated==false)
        {
            Debug.Log("activation du cube " + coord);
            GetComponent<Renderer>().material = reaveled;
            GridSpawner gridSpawner=GameObject.Find("GridSpawner").GetComponent<GridSpawner>();
            gridSpawner.sweeperManager.Activate(coord);
            activated=true;
        }
    }
}
