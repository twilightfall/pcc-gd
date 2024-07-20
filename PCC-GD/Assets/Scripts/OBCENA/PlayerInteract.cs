using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerInteract : MonoBehaviour
{
    private ItemPickup _item;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.gameObject.CompareTag("Interactable"))
        {
            this._item = other.GetComponent<ItemPickup>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Interactable"))
        {
            this._item = null;
        }
    }

    public void OnInteract(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            if(this._item != null && !InventoryManager.Instance.InventoryFull())
            {
                this._item.Interact();
            }
        }
    }

    public void OnDrop(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            if(InventoryManager.Instance.Inventory.Count != 0)
            {
                InventoryManager.Instance.DropItem();
            }
        }
    }
}
