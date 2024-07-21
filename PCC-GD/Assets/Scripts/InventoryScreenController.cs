using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
            //RectTransform InventoryGrid = (RectTransform)Panel.GetChild(1);
            
            RectTransform InventoryGrid = (RectTransform)Panel.transform.Find("InventoryGrid");
            if(!Panel.gameObject.activeSelf){
                Panel.gameObject.SetActive(true);
                Time.timeScale = 0f;

                foreach(GameObject item in PlayerInventoryController.Inventory){
                    GameObject gridCell = new GameObject();
                    gridCell.gameObject.name = "gridCell";

                    gridCell.AddComponent<TextMeshProUGUI>();
                    gridCell.AddComponent<LayoutElement>();
                    TextMeshProUGUI itemText = gridCell.GetComponent<TextMeshProUGUI>();
                    itemText.text = item.gameObject.name;
                    itemText.enableAutoSizing = true;
                    //gridCell.transform.parent = InventoryGrid.transform;
                    gridCell.transform.SetParent(InventoryGrid.transform, false);
                }
            }

            else{
                Panel.gameObject.SetActive(false);
                Time.timeScale = 1f;
                //remove all the children of inventory grid;
                int cellCount = InventoryGrid.childCount;
                for(int i = cellCount - 1; i > -1; i--){
                    Destroy(InventoryGrid.GetChild(i).gameObject);
                }
            }
        }   
    }
}