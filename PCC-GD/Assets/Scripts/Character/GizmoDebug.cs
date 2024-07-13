using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDebug : MonoBehaviour
{
    CharacterController controller;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, -transform.up * ((controller.height / 2) + distance), Color.red);
    }
}
