using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public int PlayerLevel;
    public int MaxHealth = 100;
    public int CurrentHealth = 100;
    public int MaxStamina = 100;
    public int CurrentStamina = 100;

    public List<GameObject> Inventory;

    public static PlayerManager Instance;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void AddItem(GameObject item)
    {
        Inventory.Add(item);
    }

    public void DropItem(GameObject item)
    {
        Inventory.Remove(item);
        Instantiate(item, this.transform);
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
