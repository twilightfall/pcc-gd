using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public Transform destination;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = destination.position;
    }
}
