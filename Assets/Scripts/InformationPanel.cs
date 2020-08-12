using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{
    public static InformationPanel iP = null;

    void Awake()
    {
        if (iP == null)
        {
            iP = this;
        }
        else if (this != iP)
        {
            Destroy(gameObject);
        }
    }

    public GameObject buttonLocationHolder;
    public GameObject productionButton;

    public Text unitName;

    public Image selectedImage;

    private void Start()
    {
       
    }


    public void SetImage(Sprite clickedSprite)
    {
        selectedImage.sprite = clickedSprite;
    }
    public void SetProduceButton(GameObject button)
    {
        if(productionButton==null && button != null)
        {
            productionButton = Instantiate(button, buttonLocationHolder.transform);
        } else if(productionButton!=null && button != null)
        {
            Destroy(productionButton);
            productionButton= Instantiate(button, buttonLocationHolder.transform);
        } else if (button == null)
        {
            Destroy(productionButton);
        }

    }
    public void SetUnitName(string name)
    {
        unitName.text = name;
    }
    public void ClickOnProduceButton()
    {
        GameManager.gM.clickedBuilding.GetComponent<Building>().CreateUnit();
    }
    
}
