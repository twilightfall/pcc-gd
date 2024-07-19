using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler    
{
    public Image image;
    public Color selectedColor, notSelectedColor;


    public void Awake()
    {
        Deselect();
    }


    public void Select()
    {
        image.color = selectedColor;
    }


    public void Deselect() 
    {
        image.color = notSelectedColor;
    }


    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject droppedObject = eventData.pointerDrag;
            InventoryItem inventoryItem = droppedObject.GetComponent<InventoryItem>();

            inventoryItem.parentAfterDrag = transform;
        }
        
    }

}
