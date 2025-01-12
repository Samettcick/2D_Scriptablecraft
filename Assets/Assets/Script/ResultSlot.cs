using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResultSlot : MonoBehaviour,IPointerDownHandler
{
    public Image Image;
    public SCItem SCItem;

    private void Awake()
    {
        Image.gameObject.SetActive(false);
    }

    

    public void OnPointerDown(PointerEventData eventData)
    {
        CraftingManager.Instance.OnMouseDownItem(SCItem);
        
        
    }    
}
