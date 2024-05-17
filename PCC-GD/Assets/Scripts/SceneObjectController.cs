using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scene1
{
    public class SceneObjectController : MonoBehaviour
    {
        public static SceneObjectController instance;

        public UnityEvent onSelectedObjectChanged;

        //[SerializeField]
        GameObject SelectedGameObject;

        private void Awake()
        {
            if (instance != null)
                Destroy(this);
            else
                instance = this;
        }

        public void SelectGameObject(GameObject selectedObject)
        {
            if (SelectedGameObject != null)
                SelectedGameObject.GetComponent<Renderer>().material.color = Color.white;

            SelectedGameObject = selectedObject;

            if (SelectedGameObject != null)
                SelectedGameObject.GetComponent<Renderer>().material.color = Color.yellow;

            onSelectedObjectChanged.Invoke();
        }

        public GameObject GetSelectedObject()
        {
            return SelectedGameObject;
        }
    }
}