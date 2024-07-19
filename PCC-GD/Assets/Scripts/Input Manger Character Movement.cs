using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


/// <summary>
/// Controls:
///  - Movement: WASD
///  - Jump: Spacebar
///  - Crouch: Left Shift
///  - Dash: Left Ctrl
/// </summary>

public class InputMangerCharacterMovement : MonoBehaviour
{

    float horizontal, vertical;
    Vector3 moveVector = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 moveVector1 = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 moveDirection = new();

    [SerializeField]
    public float movementSpeed;

    public InputActionReference move;
    public InputActionReference jumpy;
    public InputActionReference crouch;
    public InputActionReference dash;

    float jump;
    float secs;
    float height = 1;
    bool crouched_switch = false;
    bool grounded = false;
    int jump2 = 0;

    [SerializeField]
    CharacterController controller;
    float rotspd = 20f;

    void Start()
    {
        transform.localScale = new Vector3(1f, height, 1f);
        print("Use WASD to move");
        print("Use Spacebar to jump");
        print("Use Left Shift to crouch");
        print("Use Ctrl to dash");
        print("Use Q to pick up objects");
        print("Use E to use objects");
        print("Use R to cycle inventory");
        print("Use T to drop object");
    }

    void Update()
    {
        moveDirection = new Vector3(move.action.ReadValue<Vector2>().x, 0.0f, move.action.ReadValue<Vector2>().y).normalized;
        secs = Time.deltaTime;

        if (controller.isGrounded)
        {
            grounded = true;
            jump2 = 0;
        }
        // else
        // {
        //     grounded = false;
        // }

        if (grounded)
        {
            if (crouched_switch)
            {
                grounded = false;
                crouched_switch = false;
                moveVector1 = new(horizontal * movementSpeed * Time.deltaTime, -height/4f, vertical * movementSpeed * Time.deltaTime);
                controller.Move(moveVector1);
                
            }
            else
            {
                horizontal = move.action.ReadValue<Vector2>().x;
                vertical = move.action.ReadValue<Vector2>().y;
                moveDirection = new Vector3(horizontal, 0.0f, vertical).normalized;
                moveVector = moveDirection * movementSpeed * Time.deltaTime;
            }

        }
        else
        {
            moveVector.y = moveVector.y + 0.5f * Physics.gravity.y * secs * secs;
            moveVector = new(horizontal * movementSpeed * Time.deltaTime, moveVector.y, vertical * movementSpeed * Time.deltaTime);
        }

    }


    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && jump2<2)
        {
            grounded = false;
            jump = 5f;
            moveVector = new(horizontal * movementSpeed * Time.deltaTime, jump * Time.deltaTime, vertical * movementSpeed * Time.deltaTime);
            jump2 += 1;
        }
    }


    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            transform.localScale = new Vector3(1f, height/2, 1f);
            grounded = false;
            crouched_switch = true;
        }
        if (context.canceled)
        {
            transform.localScale = new Vector3(1f, height, 1f);
            crouched_switch = false;
            if (grounded)
            {
                moveVector1 = new(horizontal * movementSpeed * Time.deltaTime, height/4f, vertical * movementSpeed * Time.deltaTime);
                controller.Move(moveVector1);
            }
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.started && grounded)
        {
            movementSpeed *= 2;
        }
        if (context.canceled && grounded)
        {
            movementSpeed /= 2;
        }
    }

    void FixedUpdate()
    {
        if (moveVector != Vector3.zero)
        {
            Quaternion spin = Quaternion.LookRotation(moveVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, spin, rotspd * Time.deltaTime);
        }
        controller.Move(moveVector);
    }
}
