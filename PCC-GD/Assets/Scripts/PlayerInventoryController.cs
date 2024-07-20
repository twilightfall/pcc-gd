using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInventoryController
{
    [HideInInspector]
    public static List<GameObject> Inventory = new List<GameObject>();
    // Start is called before the first frame update

    private static void Awake(){
        Inventory = new List<GameObject>();
        //This should be callable???
    }

    public static void AddItemToInventory(GameObject item){
        Inventory.Add(item);
    }
}
