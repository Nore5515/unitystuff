using UnityEngine;
using System.Collections;

public class JumpFly : MonoBehaviour {

	public float jumpStrength;

	public float distToGround;

	private bool flag = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!flag) {
			Debug.Log ("Update");
		}

		if (Input.GetButtonDown ("Jump")) {
			this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpStrength, 0.0f));

		}

	}

	public bool IsGrounded () {
		return Physics.Raycast(transform.position, -Vector3.up, 0.1f);
	}


}
