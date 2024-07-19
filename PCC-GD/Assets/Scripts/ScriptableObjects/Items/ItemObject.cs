using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum ItemType
{
    Food,
    Equipment,
    KeyItem,

}

public abstract class ItemObject : ScriptableObject
{
    public Sprite itemIcon;
    public GameObject itemPrefab;
    public ItemType type;
    public int itemID;
    public bool stackable = true;

    [TextArea]
    public string description;
}
