using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerCharacterMovement : MonoBehaviour
{
    float horizontal, vertical, jump;
    Vector3 moveVector = new();
    Vector3 jumpVector;

    [SerializeField]
    float mspd = 25f;

    [SerializeField]
    CharacterController controller;

    bool isGrounded = true;
    bool isJumping = false;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");

        moveVector.Set(horizontal, jump, vertical);

        Jump();
        Move();
    }

    private void Jump()
    {
        if(controller.isGrounded && !isJumping && jump > 0)
        {
            isJumping = true;
            isGrounded = false;
            jumpVector.y = jump * 3f;
        }
        else
        {
            isGrounded = true;
            isJumping = false;
            jumpVector.y += Physics.gravity.y * Time.deltaTime;
            controller.Move(jumpVector * Time.deltaTime);
        }
    }

    private void Move()
    {
        moveVector.y = jumpVector.y;
        controller.Move(mspd * Time.deltaTime * moveVector);
    }
}
