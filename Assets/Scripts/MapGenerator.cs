using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator mG = null;

    void Awake()
    {
        if (mG == null)
        {
            mG = this;
            DontDestroyOnLoad(this);
        }
        else if (this != mG)
        {
            Destroy(gameObject);
        }
    }




    [SerializeField]
    private int width;
    [SerializeField]
    private int height;
    public GameObject[,] cellArray;

    public GameObject cell;

    Tile tileScript;

    void Start()
    {
        width = 62;
        height = 62;
        cellArray = new GameObject[width, height];
        SpawnTiles();       
    }
    /// width x height matris şeklinde tile spawnlanır.
    public void SpawnTiles()
    {
        Vector3 thisPos = GetPosition();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                cellArray[x, y]=Instantiate(cell, thisPos + new Vector3(x*(0.32f), -y*(0.32f), 0), Quaternion.identity);
                cellArray[x, y].GetComponent<Tile>().row = y;
                cellArray[x, y].GetComponent<Tile>().col = x;
            }
        }
    }

    /// Tileların komşularını döndürür.
    public List<Tile> GetNeighbours(Tile tile)
    {
        List<Tile> neighbours = new List<Tile>();

        for(int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;
                int checkX = tile.col+x;
                int checkY = tile.row + y;

                if(checkX>=0 && checkX< width && checkY>=0 && checkY< height)
                {
                    neighbours.Add(cellArray[checkX, checkY].GetComponent<Tile>());
                }
            }
        }

        return neighbours;
    }

    /// Map kurulumu için başlangıç pozisyonunu verir. (Bu script boş bir gameobject'e (TileMap) atalı)
    private Vector3 GetPosition()
    {
        return transform.position;
    }


    /// Array sınırları için kontrol.
    public bool inBoundsCheck(int col, int row)
    {
        return (row >= 0) && (col >= 0) && (row <=height) && (col <= width);
    }

}
