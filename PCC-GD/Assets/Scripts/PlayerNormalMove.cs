using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerNormalMove : MonoBehaviour
{
    private Vector2 moveInputs;
    public const float normalMoveSpeed = 8f;
    private float moveSpeed = normalMoveSpeed;
    public float sprintSpeed = 12f;
    public float crouchSpeed = 4f;
    private bool isSprinting = false;
    private bool isCrouching = false;
    private float rotationSpeed = 1000f;
    private Vector2 LastKnownGoodVector;

    private CharacterController controller;
    private void Start(){
        controller = GetComponent<CharacterController>();
    }

    public void CaptureMoveInput(InputAction.CallbackContext context){
        moveInputs = context.ReadValue<Vector2>();
    }

    public void CaptureDashInput(InputAction.CallbackContext context){
        if(context.performed){
            isSprinting = true;
            if(isCrouching) isCrouching = false;
        }
        if(context.canceled){
            isSprinting = false;
        }
    }

    public void CaptureCrouchInput(InputAction.CallbackContext context){
        if(context.performed){
            isCrouching = true;
            if(isSprinting) isSprinting = false;
            transform.localScale = new Vector3(1f, 0.5f, 1f);
        }
        if(context.canceled){
            isCrouching = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void Move(){
        bool isJumping = GetComponent<PlayerNormalJump>().isJumping;
        if(!isJumping){
            LastKnownGoodVector = moveInputs;

            if(isSprinting)
                moveSpeed = sprintSpeed;
            else if(isCrouching)
                moveSpeed = crouchSpeed;
            else
                moveSpeed = normalMoveSpeed;
        }

        Vector3 direction = new(LastKnownGoodVector.x, 0, LastKnownGoodVector.y);
        if(direction != Vector3.zero){
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        controller.Move(moveSpeed * Time.deltaTime * direction);
    }

    private void Update(){   
        Move();
    }

}
