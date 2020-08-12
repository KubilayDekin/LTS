using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Parent class
public class Building:MonoBehaviour
{
    public string buildingName;
    public int colSize;
    public int rowSize;
    public int rowCoordinate;
    public int colCoordinate;
    public GameObject producedUnit;
    public GameObject unitButton;

    public Sprite buildingSprite;

    public virtual void CreateUnit() { }

}
