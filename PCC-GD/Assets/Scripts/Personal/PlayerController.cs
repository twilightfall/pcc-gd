using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 4f;
    private float jumpSpeed = 6f;

    private bool isGrounded;
    private bool isJumping;
    private int numJumps;

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
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");

        velocity.x = horizontal * movementSpeed;
        velocity.z = vertical * movementSpeed;

        //RaycastHit hit;
        // Foot of player when pivot is set to the bottom of the player
        //Vector3 playerFoot = new Vector3(transform.position.x, transform.position.y - capsuleCollider.height / 2f, transform.position.z);
        
        // Workaround when "adjusting" the pivot point of Unity primitive objects
        Vector3 playerFoot = transform.position;
        isGrounded = Physics.Raycast(origin: playerFoot,
                                     direction: -transform.up,
                                     //out hit,
                                     maxDistance: controller.skinWidth
                                     );

        //Debug.DrawLine(playerFoot, hit.point);
        if (isGrounded)
        {
            numJumps = 0;
            velocity.y = 0f;
            
            if (jump > 0)
            {
                jump = 0f;
                numJumps++;
                isJumping = true;
                velocity.y = jumpSpeed;
                print(jumpSpeed - (jumpSpeed / 3));
            }
        }
        else
        {
            velocity.y += Physics.gravity.y * Time.deltaTime * 2f;
            if (Input.GetKeyDown(KeyCode.Space) &&  numJumps == 1)
            {
                print("Here!");
                numJumps++;
                velocity.y += (jumpSpeed * 0.75f);
            }
        }

        // Dashing
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            print("Dashing");
            velocity.x *= 1.5f;
            velocity.z *= 1.5f;
        }

        // Crouching
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            gameObject.transform.localScale -= new Vector3(0f, 0.5f, 0f);
        }
        else if ((Input.GetKeyUp(KeyCode.LeftControl)))
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }


        Vector3 movement = Time.deltaTime * velocity;
        controller.Move(movement);


        //print($"Velocity: {velocity}");
        //print($"Ray Hit {isGrounded}, {playerFoot}; Velocity: {velocity}; Movement: {movement}; Movement Norm: {movement.normalized}");

    }
}
