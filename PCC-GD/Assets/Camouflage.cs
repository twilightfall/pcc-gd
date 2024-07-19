using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camouflage : MonoBehaviour
{
    Material rend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        rend = gameObject.GetComponent<Renderer>().material;
        PlayerManager.instance.player.GetComponent<Renderer>().material = rend;
    }
}
