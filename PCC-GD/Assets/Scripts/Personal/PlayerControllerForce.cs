using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerForce : MonoBehaviour
{
    float horizontal, vertical, jump;
    public float speed = 8.0f;

    Vector3 moveVector;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");

        moveVector = new Vector3(horizontal, 0f, vertical);

        // Use Translate if you want to move any Game objects without considering any collisions
        //transform.Translate(moveVector * speed);

        // Moving objects with collisions considered
        rb.AddForce(moveVector.normalized * speed * Time.deltaTime, ForceMode.Force);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(Vector3.up * 100, ForceMode.Force);
        //}



    }
}
