using UnityEngine;
using System.Collections;


public class EnemyDestroy : MonoBehaviour
{
	GameObject player;                         
	public bool playerInRange;                         
	
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");


	}
	
	
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if (other.gameObject == player) {
			// ... the player is in range.
			playerInRange = true;
			Debug.Log("Destroy");
		}

	}
	
	
	void OnTriggerExit (Collider other)
	{
		// If the exiting collider is the player...
		if (other.gameObject == player) {
			// ... the player is no longer in range.
			playerInRange = false;
		}
	}
	
	
	void Update ()
	{
		// Add the time since Update was last called to the timer.
		if (playerInRange) {
			Destroy (gameObject);
			
			
			
		}
		}
}
	
	
	
