using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

	public Collider toot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {

			Debug.Log ("Mouse Button Pressed: MeleeAttack");

			//toot.enabled = !toot.enabled;

		}

	}
}
