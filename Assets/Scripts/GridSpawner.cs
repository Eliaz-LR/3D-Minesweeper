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
        Vector2 coords = DifficultyGrid.getSize();
        x=(int)coords.x;
        y=(int)coords.y;
        for (int h = -x; h < x; h++)
        {
            for (int v = -y; v < y; v++)
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