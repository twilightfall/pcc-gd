using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            print("You hit me! :(");
        }

        collision.rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Y U HIT ME");
        }
    }
}
