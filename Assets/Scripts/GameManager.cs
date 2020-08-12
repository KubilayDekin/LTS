using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gM = null;

    void Awake()
    {
        if (gM == null)
        {
            gM = this;
            DontDestroyOnLoad(this);
        } else if (this != gM)
        {
            Destroy(gameObject);
        }
    }

    public GameObject selectedBuilding;
    public GameObject place;
    public GameObject tile;

    Tile tileScript;
    MapGenerator mapGeneratorScript;

    public GameObject barracksMenu;
    ProductionMenu barracksMenuScript;

    public GameObject clickedBuilding;
    public GameObject clickedUnit;
    private bool isBuildingSelected;

    
    void Start()
    {
        barracksMenuScript = barracksMenu.GetComponent<ProductionMenu>();
        mapGeneratorScript = GameObject.Find("TileMap").GetComponent<MapGenerator>();
        tileScript = tile.GetComponent<Tile>();

        isBuildingSelected = false;        
    }
    void Update()
    { 
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (isBuildingSelected)
        {            
            place.transform.position = worldPosition;
        }

    }

    public void InstantiateBuilding(GameObject building, GameObject greenRectangle)
    {
        if (isBuildingSelected == false)
        {
            place = Instantiate(greenRectangle, new Vector3(0, 0, 0), Quaternion.identity);
            selectedBuilding = building;
            isBuildingSelected = true;
        }

    }

    //objeyi yerleştir ve karelerin isEmpty değişkenini ayarla
    public void PlaceObjectAndFillTile(Vector3 tilePos,int row,int col)
    {
        if (isBuildingSelected)
        {
            int colSize = selectedBuilding.GetComponent<Building>().colSize;
            int rowSize = selectedBuilding.GetComponent<Building>().rowSize;

            if (checkTiles(row, col, rowSize, colSize) && isBuildingSelected)
            {
                Destroy(place);
                GameObject gO=Instantiate(selectedBuilding, tilePos, Quaternion.identity);

                // En sol alttaki tile'ın row ve col değerleri atanıyor.
                gO.GetComponent<Building>().rowCoordinate = row;
                gO.GetComponent<Building>().colCoordinate = col;

                // bunun parametre alan versiyonunu yap
                for (int i = 0; i < colSize; i++)
                {
                    for (int j = 0; j < rowSize; j++)
                    {
                        mapGeneratorScript.cellArray[col + i, row - j].GetComponent<Tile>().MakeCellFilled();
                    }
                }

                isBuildingSelected = false;
            }
            else
            {
                Debug.Log("KARELER DOLU. FARKLI BİR YERLEŞİM YERİ SEÇİNİZ.");
            }

        }

    }

    // kareler inşaata müsait mi?
    private bool checkTiles(int row, int col, int rowSize, int colSize)
    {
        for (int i = 0; i < colSize; i++)
        {
            for (int j = 0; j < rowSize; j++)
            {
                if(mapGeneratorScript.cellArray[col + i, row - j].GetComponent<Tile>().isEmpty == true)
                    continue;
                else
                    return false;
            }
        }
        return true;
    }

}
