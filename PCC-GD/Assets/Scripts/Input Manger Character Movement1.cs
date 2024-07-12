using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputMangerCharacterMovement1 : MonoBehaviour
{

    float horizontal, vertical;
    Vector3 moveVector = new();
    Vector3 moveDirection = new();

    //Rigidbody rb;

    bool isJumping;

    [SerializeField]
    private float movementSpeed;

    public InputActionReference move;
    public InputActionReference jumpy;

    float jump;
    float secs;
    float accel;
    float v_y;

    [SerializeField]
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        movementSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal = Input.GetAxis("Horizontal");
        // vertical = Input.GetAxis("Vertical");
        // jump = Input.GetAxis("Jump")*10 + Physics.gravity.y;

        moveDirection = new Vector3(move.action.ReadValue<Vector2>().x, 0.0f, move.action.ReadValue<Vector2>().y).normalized;


        secs = Time.deltaTime;
        // jump = Input.GetAxis("Jump")*10 - (0.5f * 9.8f * secs * secs)*10;

        if (controller.isGrounded)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            jump = Input.GetAxis("Jump") * 0.5f;
            moveVector = new(horizontal, jump, vertical);
            moveVector = moveVector * movementSpeed * Time.deltaTime;
            print("hey");
        }
        else
        {
            //v_y = v_y + Physics.gravity.y * secs;
            print("nay");
            moveVector.y = moveVector.y + 0.5f * Physics.gravity.y * secs * secs;
            moveVector = new(horizontal * movementSpeed * Time.deltaTime, moveVector.y, vertical * movementSpeed * Time.deltaTime);
        }

        // moveVector = new(horizontal * movementSpeed * Time.deltaTime, jump, vertical * movementSpeed * Time.deltaTime);

        // transform.Translate(moveVector);
        controller.Move(moveVector);
        //controller.Move(moveDirection * movementSpeed * Time.deltaTime);


    }


    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isJumping = true;
            print("true");
        }
    }

    void FixedUpdate()
    {

        // rb.AddForce(moveVector.normalized * movementSpeed * Time.deltaTime, ForceMode.Force);
    }
}
