using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    

    [Header("UI")]
    public Image image;

    [HideInInspector] public ItemObject item;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitializeItem(ItemObject newItem)
    {
        item = newItem;
        image.sprite = newItem.itemIcon;
    }


    public void RemoveItem()
    {
        Destroy(gameObject);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

    }

}
