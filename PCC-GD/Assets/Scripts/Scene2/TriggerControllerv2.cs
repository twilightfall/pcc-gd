using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControllerv2 : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(prefab, spawnPoint);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("triggerExit");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("triggerStay");
        }
    }
}
