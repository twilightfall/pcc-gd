using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<GameObject> Inventory = new List<GameObject>();

    [SerializeField]
    private GameObject _bottle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddItem(int itemNum)
    {
        switch(itemNum)
        {
            case 0:
                Inventory.Add(this._bottle);
                CanvasManager.Instance.SetInventoryCount(Inventory.Count);
                break;
            case 1:
                Debug.Log("nothing");
                break;
        }
    }

    public void DropItem()
    {
        Instantiate(Inventory[0], PlayerManager.Instance.PlayerDropPosition().position, Quaternion.identity);
        Inventory.Remove(Inventory[0]);
        CanvasManager.Instance.SetInventoryCount(Inventory.Count);
    }

    public bool InventoryFull()
    {
        if(Inventory.Count == 5)
        {
            return true;
        }

        return false;
    }
}
