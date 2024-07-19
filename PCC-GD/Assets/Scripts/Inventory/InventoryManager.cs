using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    [HideInInspector] public int selectedSlot = -1;


    public void ChangeSelectSlot(int newValue)
    {
        if (selectedSlot >= 0)
        { 
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }


    public bool AddItem(ItemObject item)
    {
        for (int slotID = 0; slotID < inventorySlots.Length; slotID++)
        {
            InventorySlot slot = inventorySlots[slotID];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();   
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                Debug.Log("Item Added");
                return true;
            }
        }

        return false;
    }


    public void RemoveItem()
    {
        if (selectedSlot >= 0)
        {
            InventorySlot slot = inventorySlots[selectedSlot];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                itemInSlot.RemoveItem();
            }

        }
    }


    public ItemObject GetCurrentItem()
    {
        if (selectedSlot >= 0)
        {
            InventorySlot slot = inventorySlots[selectedSlot];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                return itemInSlot.item;
            }

        }

        return null;
    }

    public void SpawnNewItem(ItemObject item, InventorySlot slot)
    {
        GameObject newItemGameObject = Instantiate(inventoryItemPrefab, slot.transform);

        //Set sprite to slot
        InventoryItem inventoryItem = newItemGameObject.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }

}
