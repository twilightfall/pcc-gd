using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    [SerializeField]
    private TMP_Text _inventoryCount;

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
}
