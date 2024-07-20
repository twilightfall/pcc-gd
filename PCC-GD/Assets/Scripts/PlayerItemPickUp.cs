using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemPickUp : MonoBehaviour
{
    private BoxCollider PickUpBounds;
    private List<GameObject> ItemsInRange;

    void Start(){
        PickUpBounds = GetComponentInChildren<BoxCollider>();
        ItemsInRange = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other){
        //check what items are in the trigger now and add to the list
        //print(other);
        if(other.gameObject.CompareTag("Pickupable")){
            ItemsInRange.Add(other.gameObject);
            //print(ItemsInRange);
        }
    }

    private void OnTriggerExit(Collider other){
        //check what items have left the trigger and remove them from the list.
        if(other.tag == "Pickupable"){
            ItemsInRange.Remove(other.gameObject);
            //print(ItemsInRange);
        }
    }

    private void OnTriggerStay(Collider other){
        //if(!other.gameObject.CompareTag("Player"))
            //print(other);
    }

    public void CapturePickUpInput(InputAction.CallbackContext context){
        //Collider[] thingsInRange = PickUpBounds.bounds.Contains;
        if(context.performed){
            foreach(GameObject item in ItemsInRange){
                print(item.gameObject.name);
            }
            if(ItemsInRange[0]){
                ItemsInRange[0].SetActive(false);
                PlayerInventoryController.AddItemToInventory(ItemsInRange[0]);
                ItemsInRange.Remove(ItemsInRange[0]);
            }
        }
    }

    public void Update(){
        //print(ItemsInRange);
    }
}
