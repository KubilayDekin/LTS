using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour
{
    public string unitName;
    public Sprite unitSprite;

    public Tile currentTile;
    public int currentRow;
    public int currentCol;

    public Tile targetTile;
    public int targetRow;
    public int targetCol;

    public bool isClickable;

    public Pathfinding pathfinding;
    List<Tile> wayOfTiles=new List<Tile>();

    private void Start()
    {
        unitName = "Soldier";
        pathfinding = gameObject.GetComponent<Pathfinding>();
        currentTile = MapGenerator.mG.cellArray[currentCol, currentRow].GetComponent<Tile>();
        isClickable = true;
    }


    private void Update()
    {
        /// Birimi sağ tık ile hedefe yönlendirirken, hedefin önünde UI var mı kontrolü yapılır. Seçili birim kontrolü yapılır.
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.gM.clickedUnit==gameObject && Input.GetMouseButtonDown(1))
        {
            targetTile=CastRay();
            if (targetTile != null)
            {
                StartCoroutine(GoToTarget());
            }
        }
    }


    /// Hedefe giderken A* algoritmasından güzergahı alır ve tile tile olarak birimi hedefe götürür.
    /// (Gidişin mümküm olmadığı tilelar hedef seçilince lag spike giriyor bunu düzelt !)
    IEnumerator GoToTarget()
    {
        pathfinding.FindPath(MapGenerator.mG.cellArray[currentCol, currentRow].GetComponent<Tile>(), targetTile);
        wayOfTiles = pathfinding.wayOfTiles;
        if (wayOfTiles != null)
        {
            targetRow = targetTile.row;
            targetCol = targetTile.col;

            isClickable = false;
            GameManager.gM.clickedUnit = null;

            for (int i = 0; i < wayOfTiles.Count; i++)
            {
                Vector3 targetPos = wayOfTiles[i].GetPosition();
                while (gameObject.transform.position != targetPos)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos, 2 * Time.deltaTime);
                    yield return null;
                }
            }

            /// Yeni hedefe sorunsuz gidebilmesi için gerekli değerler atanır.
            currentTile.isEmpty = true;
            currentCol = targetCol;
            currentRow = targetRow;
            currentTile = targetTile;
            targetRow = 0;
            targetCol = 0;
            wayOfTiles = null;
            targetTile.isEmpty = false;
            targetTile = null;
            isClickable = true;
        }

    }


    ///  Mouse ile sağ tıklanan tile'ı döndürür.
    public Tile CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        /// Tıklanan ögenin tagini kontrol eder. Tıklanan bölgenin tile olup olmadığı tag ile kontrol edilir.
        if (hit && hit.collider.gameObject.tag=="Tile")
        {
            return hit.collider.gameObject.GetComponent<Tile>();
        }
        else return null;
    }


    /// Birime tıklandığında paneldeki ögeleri set eder.
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && isClickable)
        {
            InformationPanel.iP.SetUnitName(unitName);
            InformationPanel.iP.SetImage(unitSprite);
            InformationPanel.iP.SetProduceButton(null);
            GameManager.gM.clickedUnit = gameObject;
        }

    }
}
