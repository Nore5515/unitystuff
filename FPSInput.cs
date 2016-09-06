using UnityEngine;
using System.Collections;

//require this script for the character controller
[RequireComponent (typeof (CharacterController))]

//Adds the script to the components menu
[AddComponentMenu ("Control Script/FPSInput")]

public class FPSInput : MonoBehaviour 
{
	//how fast to move
	public float speed = 6.0f;

	//reference the controller on the player
	private CharacterController _charController;

	//create a gravity variable
	public float gravity = 20.0f;

	//how much force to jump with (how high)
	public float jumpSpeed = 8.0f;

	//variable to hold the direction of player movement
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () 
	{
		//assign the component to the variable
		_charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if the character controller is on the floor
		if (_charController.isGrounded)
		{
			//capture the player's input
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"),
			                             0, Input.GetAxis ("Vertical"));

			//use the players input to change the direction of the transform
			//of the object this script is attached to (the player)
			moveDirection = transform.TransformDirection (moveDirection);

			//add how fast to move
			moveDirection *= speed;

			//Jump is the Unity keyword for the Spacebar
			if (Input.GetButton ("Jump"))
			{
				//add jump force when the player presses the spacebar
				moveDirection.y = jumpSpeed;
			}

		}
			//bring the player back down to earth
			//Time.deltaTime slows the Update process to actual time and
			//not Frames Per Second
			moveDirection.y -= gravity * Time.deltaTime;
			
			//move the character controller, which moves the player
			_charController.Move (moveDirection * Time.deltaTime);
	}
}










