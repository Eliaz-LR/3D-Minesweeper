using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    Vector3 position;
    public GameObject prefab;
    public int x=8;
    public int y=8;


    public void SpawnGrid()
    {
        Vector2Int coords = DifficultyGrid.getSize();
        x=coords.x;
        y=coords.y;
        for (int h = -x/2; h < x/2; h++)
        {
            for (int v = -y/2; v < y/2; v++)
            {
                position = new Vector3((float)(h),0f,(float)(v));
                Instantiate(prefab, position, prefab.transform.rotation);  
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}