using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler,IPointerUpHandler
{ 
   public SCItem SCItem;
    public Image Image;
    public Text Text;
    public int itemCount;

    public void Awake()
    {       
       Image.gameObject.SetActive(false);
       Text.gameObject.SetActive(false);
        
        
    }

    public bool isActive;
    
    public void SetItem(SCItem item)
    {
        if (item != null)
        {
            SCItem = item;
            Image.gameObject.SetActive(true);
            Image.sprite = item.itemSprite;
        }     
    }
    public void RemoveItem()
    {
        SCItem = null;        
        Image.gameObject.SetActive(false);
        Image.sprite = null;
        
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        CraftingManager.Instance.OnMouseDownItem(SCItem);
        RemoveItem();       
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        CraftingManager.Instance.OnMouseUpItem();
        CraftingManager.Instance.RecipeControl();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isActive = true;   
    }

   public void OnPointerExit(PointerEventData eventData)
    {        
        isActive = false;
    } 

}
