using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    Vector3 position;
    public GameObject prefab;

    public GameObject decorEasy;
    public GameObject decorMedium;
    public GameObject decorHard;

    public int x=8;
    public int y=8;
    public SweeperManager sweeperManager;
    public GameObject[,] squareObjectCollection;

    private void SpawnGrid()
    {
        squareObjectCollection=new GameObject[x,y];
        for (int h = 0; h < x; h++)
        {
            for (int v = 0; v < y; v++)
            {
                position = new Vector3((float)(h-x/2),0f,(float)(v-y/2));
                GameObject obj = Instantiate(prefab, position, prefab.transform.rotation);
                obj.GetComponentInChildren<RayRecever>().setCoord(new Vector2Int(h,v));
                squareObjectCollection[h,v]=obj;
            }
        }
        sweeperManager.squareObjectCollection=squareObjectCollection;
    }

    private void ManagerInit()
    {
        int nbMines=DifficultyGrid.nbMines;
        sweeperManager=new SweeperManager(new Vector2Int(x,y),nbMines);
    }

    private void SpawnDecor()
    {
        if(DifficultyGrid.difficulty=="easy")
        {
            decorEasy.SetActive(true);
        }
        else if (DifficultyGrid.difficulty == "medium")
        {
            decorMedium.SetActive(true);
        }
        else
        {
            decorHard.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Vector2Int coords = DifficultyGrid.getSize();
        x=coords.x;
        y=coords.y;

        ManagerInit();
        SpawnGrid();
        SpawnDecor();
        squareObjectCollection[0,0].GetComponentInChildren<RayRecever>().updateFlagNumber();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}