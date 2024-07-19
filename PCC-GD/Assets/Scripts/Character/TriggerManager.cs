using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public void OnTriggerEnter(Collider other)
    {
        //GameObject item = other.GetComponent<GameObject>();
        ItemSet itemSetObject = other.GetComponent<ItemSet>();
        if (itemSetObject != null)
        {
            ItemObject itemObject = itemSetObject.item;
            if (itemObject != null)
            {
                bool isInventoryNotFull = inventoryManager.AddItem(itemObject);
                
                if (isInventoryNotFull)
                {
                    Destroy(other.gameObject);
                }

                if (inventoryManager.selectedSlot == -1)
                {
                    inventoryManager.ChangeSelectSlot(0);
                }
            }
        }
        
    }
}
