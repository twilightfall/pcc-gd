using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateItems : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 spawnOrigin;
    public int numToSpawn = 5;

    public void Populate()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            float rnd_x = Random.Range(-3.0f, 3.0f);
            float rnd_z = Random.Range(-3.0f, 3.0f);

            float pos_x = spawnOrigin.x + rnd_x;
            float pos_z = spawnOrigin.z + rnd_z;

            Instantiate(prefab, new Vector3(pos_x, spawnOrigin.y, pos_z), Quaternion.identity);
        }
    }
}
