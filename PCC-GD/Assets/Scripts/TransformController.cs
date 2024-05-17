using Scene1;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    [SerializeField] TMP_InputField PosX;
    [SerializeField] TMP_InputField PosY;
    [SerializeField] TMP_InputField PosZ;
    [SerializeField] TMP_InputField RotX;
    [SerializeField] TMP_InputField RotY;
    [SerializeField] TMP_InputField RotZ;
    [SerializeField] TMP_InputField ScaleX;
    [SerializeField] TMP_InputField ScaleY;
    [SerializeField] TMP_InputField ScaleZ;

    public void SetGameObject()
    {
        GameObject selectedObject = SceneObjectController.instance.GetSelectedObject();
        if (selectedObject != null)
        {
            PosX.interactable = true;
            PosY.interactable = true;
            PosZ.interactable = true;
            RotX.interactable = true;
            RotY.interactable = true;
            RotZ.interactable = true;
            ScaleX.interactable = true;
            ScaleY.interactable = true;
            ScaleZ.interactable = true;

            PosX.text = selectedObject.transform.position.x.ToString();
            PosY.text = selectedObject.transform.position.y.ToString();
            PosZ.text = selectedObject.transform.position.z.ToString();
            RotX.text = selectedObject.transform.rotation.x.ToString();
            RotY.text = selectedObject.transform.rotation.y.ToString();
            RotZ.text = selectedObject.transform.rotation.z.ToString();
            ScaleX.text = selectedObject.transform.localScale.x.ToString();
            ScaleY.text = selectedObject.transform.localScale.y.ToString();
            ScaleZ.text = selectedObject.transform.localScale.z.ToString();
        }
        else
        {
            PosX.interactable = false;
            PosY.interactable = false;
            PosZ.interactable = false;
            RotX.interactable = false;
            RotY.interactable = false;
            RotZ.interactable = false;
            ScaleX.interactable = false;
            ScaleY.interactable = false;
            ScaleZ.interactable = false;
        }
    }

    public void SetPosition()
    {
        GameObject selectedObject = SceneObjectController.instance.GetSelectedObject();
        if (selectedObject != null)
        {
            selectedObject.transform.position = new Vector3(float.Parse(PosX.text), float.Parse(PosY.text), float.Parse(PosZ.text));
            
            if(selectedObject.transform.rotation.x != float.Parse(RotX.text) || selectedObject.transform.rotation.y != float.Parse(RotY.text) || selectedObject.transform.rotation.z != float.Parse(RotZ.text))
                selectedObject.transform.Rotate(float.Parse(RotX.text), float.Parse(RotY.text), float.Parse(RotZ.text));

            selectedObject.transform.localScale = new Vector3(float.Parse(ScaleX.text), float.Parse(ScaleY.text), float.Parse(ScaleZ.text));
        }
    }
}
