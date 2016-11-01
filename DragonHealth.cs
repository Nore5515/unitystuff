using UnityEngine;
using System.Collections;

public class DragonHealth : MonoBehaviour {
	public int health = 100;
	public int oldhealth;
	Vector3 position;
	Quaternion rot;
	bool SSwordcollide = false;
	bool ignoreTrigger = false;
	// Use this for initialization
	void Start () {
		position = new Vector3 (1, 1, 1);
		rot = new Quaternion (0, 0, 0, 0);
		oldhealth = health;
		//Instantiate (this, position, rot);
	}
	// Update is called once per frame
	void Update () {
		Debug.Log (SSwordcollide);
		if (SSwordcollide == true) {
			health = health -5;
			ignoreTrigger = true;
		}
		if (health == 0) {
			//Destroy(this);
			health = oldhealth;
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("shortSword")) {
			if (ignoreTrigger == false)
				SSwordcollide = true;
			SSwordcollide = false;
		} 
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("shortSword")) {
			SSwordcollide = false;
			ignoreTrigger = false;
		}
	}
}
