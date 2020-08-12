using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionMenu : MonoBehaviour
{
    public GameObject instantiatedObject;
    public GameObject greenRectangle;

    void Start()
    {
    }
    public void SelectBuilding()
    {
        GameManager.gM.InstantiateBuilding(instantiatedObject,greenRectangle);
    }
    public GameObject InstantiateBarracks()
    {
        return instantiatedObject;
    }
}
