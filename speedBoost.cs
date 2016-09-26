using UnityEngine;
using System.Collections;

public class speedBoost : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject Player = GameObject.Find("Player");
		FPSInput moveScript = Player.GetComponent<FPSInput>();
		if (Input.GetKeyDown (KeyCode.Mouse1))
		{
			moveScript.speed = 60.0f;
		}
		
		if (Input.GetKeyUp (KeyCode.Mouse1))
		{
			moveScript.speed = 6.0f;
		}
	}
}
