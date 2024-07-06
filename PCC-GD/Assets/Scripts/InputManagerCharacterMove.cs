using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerCharacterMove : MonoBehaviour
{
    float horizontal, vertical, jump;
    Vector3 moveVector;
    Rigidbody rb;
    [SerializeField] //decorator to expose the below variable in the inspector, but retains its protected/private status
    float moveSpeed = 10f;

    [SerializeField]
    bool isJumping = false;
    // Start is called before the first frame update

    CharacterController controller;
    void Start()
    {
        /*try{
            rb = GetComponent<Rigidbody>(); //this can be replaced by using [SerializeField] and just referencing the object in the inspector
        }catch{}*/
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if(!isJumping && controller.isGrounded){
            print("are we reinitializing??");
            jump = Input.GetAxis("Jump");
            isJumping = true;
        }
        if(isJumping && controller.isGrounded)
            isJumping = false;

        moveVector = new(horizontal, jump, vertical);

        //basically teleporting - 1st method
        //transform.Translate(moveVector);

        //physics based movement - but it is too slow as it framerate dependent - 2nd method
        //rb.AddForce(moveVector.normalized * moveSpeed * Time.deltaTime, ForceMode.Force);

        //to jump using the controller, you must first check if you are grounded, and is not currently jumping, gravity applied in the air
        controller.Move(moveVector.normalized * moveSpeed * Time.deltaTime);

        if(!controller.isGrounded){
            print(jump);
            jump = jump + (Physics.gravity.y * (Time.deltaTime * Time.deltaTime) * moveSpeed * 2);
        }
    }

    private void FixedUpdate(){
        //2nd method, variation
        //character movement doesn't need ForceMode.force, usually just for objects we don't have direct control over in the game
        //rb.AddForce(moveVector * moveSpeed * Time.deltaTime);
        //this is good for physics, but for characters, this may not be what you want as they move differently.

        //Use a character controller component instead! - 3rd method
    }
}
