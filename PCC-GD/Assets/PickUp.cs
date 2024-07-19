using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update    public GameObject prefab;
    public GameObject potion;

    private void OnTriggerStay(Collider other)
    {
        if (PlayerManager.instance.get_item)
        {
            PlayerManager.instance.Inventory.Add(potion);
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            PlayerManager.instance.get_item = false;
        }
    }
}
