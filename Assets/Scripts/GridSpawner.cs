using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    Vector3 position;
    public GameObject prefab;
    public int x=5;
    public int y=5;


    public void SpawnGrid()
    {
        for (int h = 0; h < x; h++)
        {
            for (int v = 0; v < y; v++)
            {
                position = new Vector3((float)h*3,10f,(float)v*3);
                Instantiate(prefab, position, prefab.transform.rotation);  
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}