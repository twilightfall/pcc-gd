using System.Collections;
using System.Collections.Generic;
using Scene1;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
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
        if(Keyboard.current.escapeKey.wasPressedThisFrame){

            if(!Panel.gameObject.activeSelf){
                Panel.gameObject.SetActive(true);
                Time.timeScale = 0f;

                foreach(GameObject gameObj in GameObject.FindGameObjectsWithTag("Interactable")){
                    if(gameObj.TryGetComponent(out GameObjectSelector controller))
                        controller.enabled = false;

                    if(gameObj.TryGetComponent(out TMP_InputField input))
                        input.enabled = false;
                }
            }

            else{
                Panel.gameObject.SetActive(false);
                Time.timeScale = 1f;

                foreach(GameObject gameObj in GameObject.FindGameObjectsWithTag("Interactable")){
                    if(gameObj.TryGetComponent(out GameObjectSelector controller))
                        controller.enabled = true;

                    if(gameObj.TryGetComponent(out TMP_InputField input))
                        input.enabled = true;
                }
            }
        }   
    }
}
