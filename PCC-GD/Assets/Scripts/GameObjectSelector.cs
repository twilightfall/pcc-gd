using Scene1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class GameObjectSelector : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Color baseColor;

    private void Awake()
    {
        baseColor = GetComponent<Renderer>().material.color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SceneObjectController.instance.GetSelectedObject() != eventData.pointerClick || SceneObjectController.instance.GetSelectedObject() == null)
            SceneObjectController.instance.SelectGameObject(eventData.pointerClick);
        else
            SceneObjectController.instance.SelectGameObject(null);
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (SceneObjectController.instance.GetSelectedObject() != eventData.pointerEnter)
            eventData.pointerEnter.GetComponent<Renderer>().material.color = Color.cyan;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (SceneObjectController.instance.GetSelectedObject() != eventData.pointerEnter || SceneObjectController.instance.GetSelectedObject() == null)
            eventData.pointerEnter.GetComponent<Renderer>().material.color = baseColor;
    }
}
