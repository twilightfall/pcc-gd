using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class CreatePotions : MonoBehaviour
{
    public GameObject health;
    public GameObject stamina;
    public GameObject speed;
    public GameObject color;
    private GameObject potion;
    
    // Start is called before the first frame update
    void Start()
    {
        potion = Instantiate(health, new Vector3(UnityEngine.Random.Range(-12.0f, 12.0f), 1.0f, UnityEngine.Random.Range(-8.0f, 0.0f)), Quaternion.identity);
        potion.name = potion.name.Replace("(Clone)","").Trim();
        potion = Instantiate(stamina, new Vector3(UnityEngine.Random.Range(-12.0f, 12.0f), 1.0f, UnityEngine.Random.Range(-8.0f, 0.0f)), Quaternion.identity);
        potion.name = potion.name.Replace("(Clone)","").Trim();
        potion = Instantiate(speed, new Vector3(UnityEngine.Random.Range(-12.0f, 12.0f), 1.0f, UnityEngine.Random.Range(-8.0f, 0.0f)), Quaternion.identity);
        potion.name = potion.name.Replace("(Clone)","").Trim();
        potion = Instantiate(color, new Vector3(UnityEngine.Random.Range(-12.0f, 12.0f), 1.0f, UnityEngine.Random.Range(-8.0f, 0.0f)), Quaternion.identity);
        potion.name = potion.name.Replace("(Clone)","").Trim();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
