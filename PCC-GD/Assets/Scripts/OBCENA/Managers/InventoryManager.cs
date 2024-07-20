using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<GameObject> Inventory = new List<GameObject>();

    [SerializeField]
    private GameObject _bottle;

    [SerializeField]
    private GameObject _healthPotion;

    [SerializeField]
    private GameObject _manaPotion;

    [SerializeField]
    private GameObject _speedPotion;

    [SerializeField]
    private GameObject _oil;

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
                break;
            case 1:
                Inventory.Add(this._healthPotion);
                break;
            case 2:
                Inventory.Add(this._manaPotion);
                break;
            case 3:
                Inventory.Add(this._speedPotion);
                break;
            case 4:
                Inventory.Add(this._oil);
                break;
        }
        CanvasManager.Instance.SetInventoryCount(Inventory.Count);
        CanvasManager.Instance.SetInventorySlots();
    }

    public void DropItem()
    {
        Instantiate(Inventory[0], PlayerManager.Instance.PlayerDropPosition().position, Quaternion.identity);
        Inventory.Remove(Inventory[0]);
        CanvasManager.Instance.SetInventoryCount(Inventory.Count);
        CanvasManager.Instance.SetInventorySlots();
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
