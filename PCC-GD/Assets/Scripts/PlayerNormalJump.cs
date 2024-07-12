using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNormalJump : MonoBehaviour
{
    private Vector2 moveInputs;
    public float jumpStrength = 5f;
    private float jumpVelocity = 0f;
    public bool isJumping = false;
    private int currentJumps = 0;
    public int maxJumps = 2;
    private float distanceToGround;

    private CharacterController controller;
    private void Start(){
        controller = GetComponent<CharacterController>();
        distanceToGround = GetComponent<CapsuleCollider>().bounds.extents.y;

    }

    public void CaptureJumpInput(InputAction.CallbackContext context){
        if(context.performed && currentJumps < maxJumps){
            Jump();
        }
    }

    private bool IsGrounded(){
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }

    private void Jump(){
        currentJumps++;
        jumpVelocity = jumpStrength;
        isJumping = true;
    }

    private void Update(){
        if(isJumping && IsGrounded() && jumpVelocity < 1){
            currentJumps = 0;
            isJumping = false;
        }

        if(!IsGrounded()){
            jumpVelocity += (Physics.gravity.y * Time.deltaTime);
        }

        controller.Move(new Vector2(0, jumpVelocity) * Time.deltaTime);
    }
}
