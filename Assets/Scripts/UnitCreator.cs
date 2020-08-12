using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreator : MonoBehaviour
{
    public static UnitCreator uC = null;

    void Awake()
    {
        if (uC == null)
        {
            uC = this;
        }
        else if (this != uC)
        {
            Destroy(gameObject);
        }
    }

    /// Parametre olarak seçili binanın en sol alt tile'ındaki row ve col değerlerini ve üreteceği birimi alır.
    /// Üretim en sol alttaki tile'ın (y-1). ve (x-1). tile'ında başlar, binanın etrafında kare çizerek devam eder.
    public void CreateSoldier(GameObject producedeUnit, int rowCoor, int colCoor)
    {
        int row = rowCoor + 1;
        int col = colCoor - 1;
        int turn = 1;
        int cycleCount = 5;
        bool endLoop = false;

        while (endLoop == false)
        {
            if (turn == 1)
            {
                for (int i = 0; i < cycleCount; i++)
                {

                    if (MapGenerator.mG.inBoundsCheck(col, row) && isSquareSpawnable(col, row))
                    {
                        GameObject unit = Instantiate(producedeUnit, MapGenerator.mG.cellArray[col, row].GetComponent<Tile>().transform.position, Quaternion.identity);
                        unit.GetComponent<Unit>().currentCol = col;
                        unit.GetComponent<Unit>().currentRow = row;
                        endLoop = true;
                        break;
                    }
                    else
                        col++;
                }
                turn++;

            }

            else if (turn == 2)
            {
                for (int i = 0; i < cycleCount; i++)
                {
                    if (MapGenerator.mG.inBoundsCheck(col, row) && isSquareSpawnable(col, row))
                    {
                        GameObject unit = Instantiate(producedeUnit, MapGenerator.mG.cellArray[col, row].GetComponent<Tile>().transform.position, Quaternion.identity);
                        unit.GetComponent<Unit>().currentCol = col;
                        unit.GetComponent<Unit>().currentRow = row;
                        endLoop = true;
                        break;
                    }
                    else
                        row--;
                }
                turn++;

            }


            else if (turn == 3)
            {
                for (int i = 0; i < cycleCount; i++)
                {
                    if (MapGenerator.mG.inBoundsCheck(col, row) && isSquareSpawnable(col, row))
                    {
                        GameObject unit = Instantiate(producedeUnit, MapGenerator.mG.cellArray[col, row].GetComponent<Tile>().transform.position, Quaternion.identity);
                        unit.GetComponent<Unit>().currentCol = col;
                        unit.GetComponent<Unit>().currentRow = row;
                        endLoop = true;
                        break;
                    }
                    else
                        col--;
                }
                turn++;

            }

            else if (turn == 4)
            {
                for (int i = 0; i < cycleCount; i++)
                {
                    if (MapGenerator.mG.inBoundsCheck(col, row) && isSquareSpawnable(col, row))
                    {
                        GameObject unit = Instantiate(producedeUnit, MapGenerator.mG.cellArray[col, row].GetComponent<Tile>().transform.position, Quaternion.identity);
                        unit.GetComponent<Unit>().currentCol = col;
                        unit.GetComponent<Unit>().currentRow = row;
                        endLoop = true;
                        break;
                    }
                    else
                        row++;
                }
                turn = 1;
                cycleCount += 2;

                row = row + turn;
                col = col - turn;


            }


        }
    }
    /// Tile'ın bina kurulumuna uygun olup olmadığını döndüren fonksiyon.
    private bool isSquareSpawnable(int col, int row)
    {
        if (MapGenerator.mG.cellArray[col, row].GetComponent<Tile>().isEmpty == true)
        {
            MapGenerator.mG.cellArray[col, row].GetComponent<Tile>().isEmpty = false;
            return true;
        }
        else
            return false;

    }

}
