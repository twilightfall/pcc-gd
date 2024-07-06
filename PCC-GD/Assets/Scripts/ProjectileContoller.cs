using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileContoller : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        //cide
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }*/
	
	public GameObject projectile;
	public Transform spawnPoint;
	
	
    private void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			print("You have entered a restricted area!");
		}		
		/*other.GetComponent<Rigidbody>().AddForce(Vector3.up * 20, ForceMode.Impulse);*/
	}
	private void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("Player")){
			print("Thank you!");
		}
		
	}
	private void OnTriggerStay(Collider other){		
		if(other.gameObject.CompareTag("Player")){
			print("Get out!");
			Instantiate(projectile, spawnPoint);
		}
	
		//projectile.GetComponent<Rigidbody>().AddForce(Vector3.up * 20, ForceMode.Impulse);
	}
}
