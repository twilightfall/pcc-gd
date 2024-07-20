using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    private int _itemNum;

    public void Interact()
    {
        InventoryManager.Instance.AddItem(this._itemNum);
        Destroy(gameObject);
    }
}
