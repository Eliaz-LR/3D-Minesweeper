using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRecever : MonoBehaviour
{

    public GridSpawner gridSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        Debug.Log("activation du cube");
        gridSpawner.SpawnGrid();
    }
}
