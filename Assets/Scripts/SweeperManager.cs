using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SweeperManager
{
    private Vector2Int size;
    private int nbMines;
    private List<Vector2Int> emplacementsMines;
    SweeperGenerator sweeperGenerator=null;
    public GameObject[,] squareObjectCollection {get; set;}

    public SweeperManager(Vector2Int size, int nbMines)
    {
        this.size = size;
        this.nbMines = nbMines;
    }
    public void Activate(Vector2Int coords)
    {
        if (sweeperGenerator==null)
        {
            sweeperGenerator=new SweeperGenerator(size,nbMines,this);
            emplacementsMines=sweeperGenerator.Generate(coords);
            Debug.Log("Generation de ce genre de grid mon gars");
        }
        if (emplacementsMines.Contains(coords))
        {
            Debug.Log("! Mine trouvée !");
            GameOver();
        }
        else
        {
            Material reaveled = squareObjectCollection[coords.x,coords.y].GetComponentInChildren<RayRecever>().reaveled;
            squareObjectCollection[coords.x,coords.y].GetComponentInChildren<Renderer>().material = reaveled;
            int nbMinesAround=GetNumberOfNeighbouringMines(coords);
            if (nbMinesAround==0)
            {
                Debug.Log("! Pas de mine autour !");
                List<Vector2Int> neighbours=GetNeighbouringCoords(coords);
                Debug.Log("! Il y a "+neighbours.Count+" voisins !");
                foreach (Vector2Int neighbour in neighbours)
                {
                    //Activate(neighbour); //!ne marche pas car ne check pas si la case est déjà activée
                    squareObjectCollection[neighbour.x,neighbour.y].GetComponentInChildren<RayRecever>().Activate();
                }
            }
            else
            {
                // Afficher le nombre de mines autour
                squareObjectCollection[coords.x,coords.y].GetComponentInChildren<TextMeshPro>().text=nbMinesAround.ToString();
            }
            if (VictoryTest())
            {
                Debug.Log("Victory");
                Victory();
            }
        }
    }
    
    public List<Vector2Int> GetNeighbouringCoords(Vector2Int coords)
    {
        List<Vector2Int> neighbours=new List<Vector2Int>();
        for (int x = coords.x-1; x <= coords.x+1; x++)
        {
            for (int y = coords.y-1; y <= coords.y+1; y++)
            {
                if (x>=0 && x<size.x && y>=0 && y<size.y && !(x==coords.x && y==coords.y))
                {
                    neighbours.Add(new Vector2Int(x,y));
                }
            }
        }
        return neighbours;
    }
    private int GetNumberOfNeighbouringMines(Vector2Int coords)
    {
        int count =0;
        for (int i = coords.x-1; i <= coords.x+1; i++)
        {
            for (int j = coords.y-1; j <= coords.y+1; j++)
            {
                if (i>=0 && i<size.x && j>=0 && j<size.y)
                {
                    if (emplacementsMines.Contains(new Vector2Int(i,j)))
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
    private bool VictoryTest()
    {
        int count=0;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                if (squareObjectCollection[x,y].GetComponentInChildren<RayRecever>().activated)
                {
                    count++;
                }
            }
        }
        if (count==size.x*size.y-nbMines+1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Victory()
    {
        GameObject.Find("StateManager").GetComponent<StateManager>().Victory();
    }
    private void GameOver()
    {
        GameObject.Find("StateManager").GetComponent<StateManager>().GameOver();
    }
}
