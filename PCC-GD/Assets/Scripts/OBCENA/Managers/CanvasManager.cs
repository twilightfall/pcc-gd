using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    [SerializeField]
    private TMP_Text _inventoryCount;

    [SerializeField]
    private TMP_Text _slot1;

    [SerializeField]
    private TMP_Text _slot2;

    [SerializeField]
    private TMP_Text _slot3;

    [SerializeField]
    private TMP_Text _slot4;

    [SerializeField]
    private TMP_Text _slot5;

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

    public void SetInventoryCount(int num)
    {
        this._inventoryCount.text = "Inventory: " + num.ToString() + "/5";
    }

    public void SetInventorySlots()
    {
        if (InventoryManager.Instance.Inventory.Count == 1)
        {
            this._slot1.text = "Slot 1: " + InventoryManager.Instance.Inventory[0].name;

        }

        if (InventoryManager.Instance.Inventory.Count == 2)
        {
            this._slot2.text = "Slot 2: " + InventoryManager.Instance.Inventory[1].name;

        }

        if (InventoryManager.Instance.Inventory.Count == 3)
        {
            this._slot3.text = "Slot 3: " + InventoryManager.Instance.Inventory[2].name;

        }

        if (InventoryManager.Instance.Inventory.Count == 4)
        {
            this._slot4.text = "Slot 4: " + InventoryManager.Instance.Inventory[3].name;

        }

        if (InventoryManager.Instance.Inventory.Count == 5)
        {
            this._slot5.text = "Slot 5: " + InventoryManager.Instance.Inventory[4].name;

        }
    }
}
