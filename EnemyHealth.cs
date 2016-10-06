using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	//
	//
	//
	//
	//
	//
	//
	//
	//
	//
	//
	//TANKS
	//
	//
	//
	//
	//
	//
	//
	//
	//
	bool takenDamage = false;
	public float maxHealth = 100.0f;
	private float health = 100.0f;
	public float minHealth = 0.0f;
	GameObject player;   
	GameObject Broken_HouseCopy;
	public float healthBarLength;
	public float damage = 10.0f;
	public Slider enemyHealth; 
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
			takenDamage = true;
			Debug.Log("KILL ME!!!!");
			
			
		}
		
	}
	void OnTriggerExit (Collider other)
	{
		// If the exiting collider is the player...
		if (other.gameObject == player) {
			// ... the player is no longer in range.
			takenDamage = false;
		}
	}
	

	void takeDamage()
	{
		if (takenDamage) {
		
			health = health - damage;
		}
		takenDamage = false;
	}
	void Start () {
		healthBarLength = Screen.width / 6;

	}

	void OnGUI() {
		Vector2 targetPos;

		targetPos = Camera.main.WorldToScreenPoint (transform.position);
		
		GUI.Box(new Rect(targetPos.x, Screen.height - 100, 60, 20), health + "/" + maxHealth);
	}



	private void SetupSlider()
	{
		//enemyHealth = GetComponent<Broken_HouseCopy> ();
		enemyHealth.minValue = minHealth;
		enemyHealth.maxValue = maxHealth;
		enemyHealth.wholeNumbers = false;
	}


	public void ChangeSliderValue()
	{
		enemyHealth.value = health;
	}

	void Update () {
		takeDamage();
		//sliderUI.value = health;
		enemyHealth.value = health;
		//Debug.Log (health);

		if (health == minHealth) {
			Destroy (gameObject);
			


		}
	}
}
