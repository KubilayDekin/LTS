using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerPlant : Building
{
    private void Awake()
    {
        buildingSprite = Resources.Load<Sprite>("Power Plant");
    }

    public PowerPlant()
    {
        buildingName = "Power Plant";
        colSize = 2;
        rowSize = 3;
        producedUnit = null;
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
}
