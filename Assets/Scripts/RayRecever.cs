using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRecever : MonoBehaviour
{

    public Material reaveled;
    private Vector2Int coord;
    public bool activated=false;
    public bool flagged=false;
    private Transform parent;
    public void setCoord(Vector2Int coord)
    {
        this.coord = coord;
        parent = transform.parent;
    }
    public void Activate()
    {
        Debug.Log("activation du cube " + coord);
        if (activated==false)
        {
            activated=true;
            if (flagged)
            {
                inverseFlag();
            }
            // GetComponent<Renderer>().material = reaveled;
            GridSpawner gridSpawner=GameObject.Find("GridSpawner").GetComponent<GridSpawner>();
            gridSpawner.sweeperManager.Activate(coord);
        }
    }
    public void flag()
    {
        Debug.Log("Flag "+coord);
        if (activated==false)
        {
            inverseFlag();
        }
    }
    public void inverseFlag()
    {
        GameObject flag = parent.GetChild(2).gameObject;
        if (flagged==false)
        {
            flag.SetActive(true);
        }
        else
        {
            flag.SetActive(false);
        }
        flagged=!flagged;
    }
}
