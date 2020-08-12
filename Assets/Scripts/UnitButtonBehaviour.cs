using UnityEngine;
using UnityEngine.EventSystems;

public class UnitButtonBehaviour : MonoBehaviour, IPointerClickHandler
{
    
    public void OnPointerClick(PointerEventData pointerEventData)
    {        
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            InformationPanel.iP.ClickOnProduceButton();
        }
    }
}
