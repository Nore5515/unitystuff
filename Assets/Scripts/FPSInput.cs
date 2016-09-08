using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]

[AddComponentMenu ("Control Script/FPSInput")]

public class FPSInput : MonoBehaviour 
{
	public float speed = 6.0f;
	private CharacterController _charController;
	public float gravity = 20.0f;
	public float jumpSpeed = 8.0f;
	private Vector3 moveDirection = Vector3.zero;

	void Start () 
	{
		_charController = GetComponent<CharacterController>();
	}

	void Update () 
	{
		if (_charController.isGrounded)
		{
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;

			if (Input.GetButton ("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		_charController.Move (moveDirection * Time.deltaTime);
	}
}