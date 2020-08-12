using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductionPanel : MonoBehaviour
{
    public Button hideButton;
    public Text hideButtonText;
    public GameObject productionPanel;

    private bool isActive=true;

    public void hideOrOpenProductionPanel()
    {
        if (isActive)
        {
            productionPanel.SetActive(false);
            hideButtonText.text = ">>>";
            isActive = false;
        }
        else
        {
            productionPanel.SetActive(true);
            hideButtonText.text = "<<<";
            isActive = true;
        }

    }
}
