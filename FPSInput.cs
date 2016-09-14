using UnityEngine;
using System.Collections;


public class FPSInput : MonoBehaviour 
{
	//how fast to move
	public float speed = 6.0f;


	//current gravity pull
	public float gravypull;
	private float oldgravypull;
	
	//reference the controller on the player
	private CharacterController _charController;
	
	//create a gravity variable
	public float gravity = 20.0f;
	
	//how much force to jump with (how high)
	public float jumpAccel;
	public float jumpSpeed = 8.0f;
	private float oldjumpSpeed;



	public float maxDelay;
	private float delay;


	public float initialJumpMultiplier;



	private float distToGround;



	public float yAccel;


	public int flightTime;

	public bool juiceleft = true;
	
	//variable to hold the direction of player movement
	private Vector3 moveDirection = Vector3.zero;
	
	// Use this for initialization
	void Start () 
	{
		delay = maxDelay;


		//assign the component to the variable
		_charController = GetComponent<CharacterController>();
		Debug.Log("up-in");
		oldgravypull = gravypull;
		oldjumpSpeed = jumpSpeed;
		yAccel = 0.0f;
		distToGround = _charController.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () 
	{



		//capture the player's input
		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"),
		                             0.0f, Input.GetAxis ("Vertical"));
		
		//use the players input to change the direction of the transform
		//of the object this script is attached to (the player)
		moveDirection = transform.TransformDirection (moveDirection);
		
		//add how fast to move
		moveDirection *= speed;







		//Jump is the Unity keyword for the Spacebar
		if (Input.GetButtonDown ("Jump") && juiceleft && !IsGrounded()) {

			Debug.Log ("Jumping with yAccel = " + yAccel);
			_charController.Move (new Vector3(0.0f, jumpSpeed, 0.0f));
			yAccel += jumpSpeed;


			//reduce fuel (flight time)
			flightTime -= 1;
			if (flightTime <= 0) {
				Debug.Log ("Out of juice");
				juiceleft = false;
			}



		}
		if (Input.GetButtonDown ("Jump") && juiceleft && IsGrounded()) {
			
			Debug.Log ("Jumping with yAccel = " + yAccel);
			_charController.Move (new Vector3(0.0f, jumpSpeed, 0.0f));
			yAccel += jumpSpeed * initialJumpMultiplier;
			
			
			//reduce fuel (flight time)
			flightTime -= 1;
			if (flightTime <= 0) {
				Debug.Log ("Out of juice");
				juiceleft = false;
			}
			
			
			
		}

		//gravity always pulling down
		yAccel -= gravypull;


		//if grounded, don't move
		if (IsGrounded()) {
			yAccel = 0.0f;
		}


		_charController.Move (new Vector3 (0.0f, yAccel, 0.0f) );

		
		
		//bring the player back down to earth
		//Time.deltaTime slows the Update process to actual time and
		//not Frames Per Second
		//moveDirection.y -= gravity * Time.deltaTime;

		//accelerate gravity pull


		
		//move the character controller, which moves the player
		_charController.Move (moveDirection * Time.deltaTime);
	}


	bool IsGrounded()  
	{
		return Physics.Raycast(_charController.transform.position, -Vector3.up, distToGround + 0.1f);
	}


}










