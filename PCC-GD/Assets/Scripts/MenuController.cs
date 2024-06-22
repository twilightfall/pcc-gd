using Scene1;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    RectTransform MenuPanel;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if(!MenuPanel.gameObject.activeSelf)
            {
                MenuPanel.gameObject.SetActive(true);
                Time.timeScale = 0f;

                foreach (GameObject t in GameObject.FindGameObjectsWithTag("Interactable"))
                {
                    if (t.TryGetComponent(out GameObjectSelector controller))
                        controller.enabled = false;

                    if (t.TryGetComponent(out TMP_InputField input))
                    {
                        input.enabled = false;
                    }
                }
            }
            else
            {
                MenuPanel.gameObject.SetActive(false);
                Time.timeScale = 1f;

                foreach (GameObject t in GameObject.FindGameObjectsWithTag("Interactable"))
                {
                    if (t.TryGetComponent(out GameObjectSelector controller))
                        controller.enabled = true;

                    if (t.TryGetComponent(out TMP_InputField input))
                    {
                        input.enabled = true;
                    }
                }
            }
        }
    }
}
