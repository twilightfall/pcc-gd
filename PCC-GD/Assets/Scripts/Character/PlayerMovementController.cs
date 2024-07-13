using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class PlayerMovementController : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 moveDir;
    public Vector3 jumpVector;

    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    public bool isGrounded = true;
    public bool isJumping = false;
    public bool canJump = true;
    public bool didJump = false;

    public float mspd = 5f;

    public float rotspd = 20f;

    // Update is called once per frame
    void Update()
    {
        GravityCheck();
        JumpAndGravity();
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {

            moveDir.Set(moveAction.action.ReadValue<Vector2>().x, 0f, moveAction.action.ReadValue<Vector2>().y);

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            didJump = true;
        }
        else if (context.canceled)
        {
            didJump = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Interactable"))
        {
            //PlayerStats.CurrentHealth -= 10;
            //print(PlayerStats.CurrentHealth);
        }
    }

    private void Move()
    {
        if (moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotspd * Time.deltaTime);
        }

        controller.Move(moveDir * mspd * Time.deltaTime);
    }

    private void GravityCheck()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, ((controller.height / 2) + 0.02f)))
        {
            isGrounded = true;
        } 
        else
        {
            isGrounded = false;
        }
    }

    private void JumpAndGravity()
    {
        if (isGrounded && canJump && didJump)
        {
            isJumping = true;
            canJump = true;
            jumpVector.y += Mathf.Sqrt(1f * -2f * Physics.gravity.y);
            controller.Move(jumpVector * Time.deltaTime);
        }
        else
        {
            jumpVector.y += Physics.gravity.y * Time.deltaTime;
            controller.Move(jumpVector * Time.deltaTime);

            if (isGrounded)
            {
                jumpVector = Vector3.zero;
                isJumping = false;
                canJump = true;
            }
        }
    }
}
