using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public List<Tile> wayOfTiles = new List<Tile>();

    public void FindPath(Tile start, Tile target)
    {
        List<Tile> openList = new List<Tile>();
        List<Tile> closedList = new List<Tile>();
        wayOfTiles = null;

        openList.Add(start);

        while (openList.Count > 0)
        {
            Tile currentTile = openList[0];
            for(int i = 1; i < openList.Count; i++)
            {
                if (openList[i].fCost < currentTile.fCost || openList[i].fCost==currentTile.fCost && openList[i].hCost<currentTile.hCost)
                {
                    currentTile = openList[i];
                }
            }
            openList.Remove(currentTile);
            closedList.Add(currentTile);

            if (currentTile == target)
            {
                RetracePath(start,target);
                return;
            }
            foreach(Tile neighbour in MapGenerator.mG.GetNeighbours(currentTile))
            {
                if(neighbour.isEmpty==false || closedList.Contains(neighbour))
                {
                    continue;
                }

                int newMovCostToNeighbour = currentTile.gCost + GetDistance(currentTile, neighbour);

                if(newMovCostToNeighbour<neighbour.gCost || !openList.Contains(neighbour))
                {
                    neighbour.gCost = newMovCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, target);
                    neighbour.parent = currentTile;

                    if (!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour);
                    }
                }
            }
        }


    }

    void RetracePath(Tile start, Tile target)
    {
        List<Tile> path = new List<Tile>();
        Tile currentNode = target;

        while (currentNode != start)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();
        wayOfTiles = path;
    }

    int GetDistance(Tile tileA, Tile tileB)
    {
        int dstX = Mathf.Abs(tileA.col - tileB.col);
        int dstY = Mathf.Abs(tileA.row - tileB.row);

        if (dstX > dstY)
        {
            return 14 * dstY + 10 * (dstX - dstY);
        }
        else
        {
            return 14 * dstX + 10 * (dstY - dstX);
        }
    }
}
