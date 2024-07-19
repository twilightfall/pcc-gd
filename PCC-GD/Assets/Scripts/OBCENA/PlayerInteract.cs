using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerInteract : MonoBehaviour
{
    private GameObject _item;
    private bool _canInteract;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Interactable"))
        {
            this._canInteract = true;
            this._item = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Interactable"))
        {
            this._canInteract = false;
        }
    }

    public void OnInteract(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            if(this._canInteract && !PlayerManager.Instance.InventoryFull()) 
            {
                Debug.Log("OnInteract");
                PlayerManager.Instance.AddItem(this._item);
                Destroy(this._item);
            }
        }
    }

    public void OnDrop(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            PlayerManager.Instance.DropItem(this._item);
        }
    }
}
