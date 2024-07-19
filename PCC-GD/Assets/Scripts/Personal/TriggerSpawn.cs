using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    public GameObject prefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < 5; i++)
            {
                int rnd_x = Random.Range(-7, 7);
                int rnd_z = Random.Range(-10, -3);

                float pos_x = prefab.transform.position.x + rnd_x;
                float pos_z = prefab.transform.position.z + rnd_z;

                Instantiate(prefab, new Vector3(pos_x, 0, pos_z), Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
