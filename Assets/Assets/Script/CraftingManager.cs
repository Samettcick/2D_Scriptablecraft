using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CraftingManager : MonoBehaviour
{    
    public SCItem CurrentSCItem;    
    public Image customcursor;
    public List<Slot> slots;   
    public List<SCRecipe> Recipes;
    public ResultSlot ResultSlot;

    public static CraftingManager Instance { get; private set;}

    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    public void RecipeControl()
    {
       
        
        foreach (var recipe in Recipes)
        {
            bool IsMatch = true;

            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].SCItem != recipe.Recipe[i])
                {
                    IsMatch = false;
                    break;
                }
            }
            if (IsMatch)
            {
                ResultSlot.SCItem = recipe.output;
                ResultSlot.Image.sprite = ResultSlot.SCItem.itemSprite;
                ResultSlot.Image.gameObject.SetActive(true);
                break;
            }
            else
            {
                ResultSlot.SCItem = null;
                ResultSlot.Image.sprite = null;
                ResultSlot.Image.gameObject.SetActive(false);
            }
        }      
           
    }
   
   

    public void OnMouseDownItem(SCItem SCItem)
    {
        if (CurrentSCItem == null)
        {
            customcursor.transform.position = Input.mousePosition;
            CurrentSCItem = SCItem;
            customcursor.sprite = CurrentSCItem.itemSprite;           
            customcursor.gameObject.SetActive(true);                       
        }
    } 

    public void OnMouseUpItem()
    {
        bool found = false;
        foreach (Slot slot in slots)
        {                     
                if (slot.isActive)
                {
                    slot.SetItem(CurrentSCItem);
                    RecipeControl();
                    CurrentRemove();
                 found = true;
                    break;
                }                 
        }
        if(!found)
        {
            CurrentRemove();
        }    
    }
    public void CurrentRemove()
    {
        CurrentSCItem = null;
        customcursor.sprite = null;
        customcursor.gameObject.SetActive(false);
    }
    
}
