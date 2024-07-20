using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryScreenController : MonoBehaviour
{
    [SerializeField]
    RectTransform Panel;
    // Start is called before the first frame update
    void Start()
    {
        Panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.iKey.wasPressedThisFrame){
            foreach(GameObject item in PlayerInventoryController.Inventory){
                print(item.gameObject.name);
            }
            
            if(!Panel.gameObject.activeSelf){
                Panel.gameObject.SetActive(true);
                Time.timeScale = 0f;

                /*foreach(){
                    //display each item in inventory
                }*/
            }

            else{
                Panel.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }   
    }
}