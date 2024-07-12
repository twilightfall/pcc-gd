using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevel;

public class PlayerController : MonoBehaviour
{
    private readonly float movementSpeed = 4f;
    private readonly float jumpSpeed = 6f;

    private bool isGrounded;
    private bool canDoubleJump;
    private bool isCrouching;

    private float horizontal, vertical, jump;

    private Vector3 moveVector;
    private Vector3 velocity;

    CharacterController controller;
    CapsuleCollider capsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //RaycastHit hit;
        // Foot of player when pivot is set to the bottom of the player
        //Vector3 playerFoot = new Vector3(transform.position.x, transform.position.y - capsuleCollider.height / 2f, transform.position.z);
        
        // Workaround when "adjusting" the pivot point of Unity primitive objects
     
        Vector3 playerFoot = transform.position;
        isGrounded = Physics.Raycast(origin: playerFoot,
                                     direction: -transform.up,
                                     //out hit,
                                     maxDistance: controller.skinWidth + 0.005f
                                     );



        //Debug.DrawLine(playerFoot, hit.point);
        if (isGrounded)
        {
            // Reset velocity when on ground
            velocity.y = 0f;

            // Set jump velocity when jumping action is prompted
            Jump();

            // Set move velocity; apply dash or crouch velocities when prompted
            // Disable dashing when player is crouching
            Move();
            Crouch();
            if (!isCrouching) Dash();
            
        }
        else
        {
            // Apply gravity and check for double jump when falling
            applyGravity();


            // Double jump if prompted
            Jump(onAir: true);

        }

        
        // Apply the movement of the player based on the calculated velocities
        Vector3 movement = Time.deltaTime * velocity;
        controller.Move(movement);

    }


    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        velocity.x = horizontal * movementSpeed;
        velocity.z = vertical * movementSpeed;
    }

    private void Jump(bool onAir = false)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("JUMP");
            if (canDoubleJump && onAir)
            {
                velocity.y = jumpSpeed * 0.75f;
                canDoubleJump = false;
                
            }
            else
            {
                if (!onAir)
                {
                    velocity.y = jumpSpeed;
                    canDoubleJump = true;
                }
            }
        }
            
    }


    private void Dash()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            velocity.x *= 1.5f;
            velocity.z *= 1.5f;
        }
    }


    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale -= new Vector3(0f, 0.5f, 0f);
            isCrouching = true;
        }
        else if ((Input.GetKeyUp(KeyCode.LeftControl)))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        
    }


    private void applyGravity()
    {
        velocity.y += Physics.gravity.y * Time.deltaTime * 2f;
    }
}
