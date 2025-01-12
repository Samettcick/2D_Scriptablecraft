using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIitem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public SCItem item;
    public void OnPointerDown(PointerEventData eventData)
    {
        CraftingManager.Instance.OnMouseDownItem(item);       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CraftingManager.Instance.OnMouseUpItem();
        
    }
}
