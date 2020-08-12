using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Barracks:Building
{

    private void Awake()
    {
        buildingSprite = Resources.Load<Sprite>("Barracks");
    }
    public Barracks()
    {
        buildingName = "Barracks";
        colSize = 4;
        rowSize = 4;
    }

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            InformationPanel.iP.SetImage(buildingSprite);
            InformationPanel.iP.SetProduceButton(unitButton);
            InformationPanel.iP.SetUnitName(buildingName);
            GameManager.gM.clickedBuilding = gameObject;
        }


    }

    /// Ünite yaratmayı tetikleyen fonksiyon
    public override void CreateUnit()
    {
        Debug.Log("Barracksa Basıldı");
        UnitCreator.uC.CreateSoldier(producedUnit, rowCoordinate, colCoordinate);
    }
    
}
