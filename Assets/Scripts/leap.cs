using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]

[AddComponentMenu ("Control Script/FPSInput")]

public class leap : MonoBehaviour 
{
	public float speed = 6.0f;
	private CharacterController controller;
	public float gravity = 12.0f;
	public float jumpSpeed = 8.0f;
	private Vector3 moveDirection = Vector3.zero;

	void Start () 
	{
		 controller = GetComponent<CharacterController>();
	}

	void Update () 
	{
		if (controller.isGrounded)
		{
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;

			if (Input.GetButton ("Leap"))
			{
				Debug.Log ("Leaping");

				this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpSpeed, 0.0f));
				this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, speed, 0.0f));

				moveDirection.x = speed;
				moveDirection.y = jumpSpeed;
			}
		}

/*		if (Collider.)
		{
			Destroy (gameObject.);
		}
*/
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);

	}
}