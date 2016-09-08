using UnityEngine;
using System.Collections;

public class JumpFly : MonoBehaviour {
	
	public float jumpStrength;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown ("Jump")) {
			Debug.Log ("Jumping");
			this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpStrength, 0.0f));
			
		}
		
	}
}