using UnityEngine;
using System.Collections;

//require this script for the character controller
[RequireComponent (typeof (CharacterController))]

//Adds the script to the components menu
[AddComponentMenu ("Control Script/FPSInput")]

public class FPSInput : MonoBehaviour {

	//how fast to move
	public float speed = 6.0f;

	//reference the controller on the player
	private CharacterController _charController;

	//create a gravity variable
	public float gravity = -9.8f;



		// Use this for initialization
	void Start () 
	{
		_charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//"Horizontal" is a Unity keyword that is tied
		//to the Left/Right arrow keys as well as the A and D Keys
		float deltaX = Input.GetAxis ("Horizontal") * speed;

		//"Vertical is the Unity keyword that is tied to the
		// Up/Down arrow keys as well as the W and S keys
		float deltaZ = Input.GetAxis ("Vertical") * speed;

		//actually move the character
		//transform.Translate (deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);

		//holding the player's input
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);

		//limits the speed of the player when moving diagonally
		movement = Vector3.ClampMagnitude (movement, speed);

		//set the movement on the Y axis to always be pulling down
		movement.y = gravity;

		//use actual time to frame the movement
		movement *= Time.deltaTime;

		//formats movement for the CharacterController to use
		movement = transform.TransformDirection(movement);

		//use dot syntax to actually move the character controller
		_charController.Move (movement);
	}
}










