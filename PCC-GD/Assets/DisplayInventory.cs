using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;
using UnityEditor.Search;

public class DisplayInventory : MonoBehaviour
{
    List<GameObject> items;
    private int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        items = PlayerManager.instance.Inventory;
        if (items.Count > 0)
        {
            gameObject.GetComponent<TMP_Text>().text = items[0].name.ToString();
            i = 1;
            while(i < items.Count)
            {
                gameObject.GetComponent<TMP_Text>().text += "\n";
                gameObject.GetComponent<TMP_Text>().text += items[i].name.ToString();
                i = i + 1;
            }
        }
        else
        {
            gameObject.GetComponent<TMP_Text>().text = "";
        }
    }
}
