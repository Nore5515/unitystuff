using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	
	//Setup the numberiung system for rotation
	// 1 is the X axis, 2 is the Y, and 0 is both
	public enum RotationAxis
	{
		MouseXandY = 0,
		MouseX = 1,
		MouseY = 2
	}
	
	//variable hold both the X and Y rotations
	public RotationAxis axes = RotationAxis.MouseXandY;
	
	public float sensitivityHor = 9.0f;
	
	//speed of the vertical look
	public float sensitivityVert = 9.0f;
	
	//limit the look angle
	public float maximumVert = 45.0f;
	public float minimumVert = -45.0f;
	
	//actual vertical angle rotates around the X axis
	private float _rotationX = 0.0f;
	
	void Start ()
	{
		//locate the rigidbody
		Rigidbody body = GetComponent<Rigidbody>();
		
		//if a rigidbody is located on this object...
		if (body != null)
		{
			//freeze the rotation values of the rigidbody so that the
			//object itself does not rotate with physics
			body.freezeRotation = true;
		}
	}
	
	
	
	// Update is called once per frame
	void Update () 
	{
		UnityEngine.Cursor.visible = false;
		if (axes == RotationAxis.MouseX)
		{
			//horizontal rotation goes here
			transform.Rotate 
				(0, Input.GetAxis ("Mouse X") * sensitivityHor, 0);
		}
		
		/*else if (axes == RotationAxis.MouseY)
		{
			//vertical rotation goes here
			//get the Mouse Y and subtract it from the _roataionX....
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			
			//And limit the angle using Unity's built-in math functions
			//If these lines do not appera, then the camera could tilt
			//completely backwards
			_rotationX = Mathf.Clamp 
				(_rotationX, minimumVert, maximumVert);
			
			//keep the Y angle the same as it was last frame
			float rotationY = transform.localEulerAngles.y;
			
			//create a new Vector3 from the stored roation values
			transform.localEulerAngles = 
				new Vector3 (_rotationX, rotationY, 0);
		}*/
		
		else 
		{
			//both horizontal and vertical
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			
			_rotationX = Mathf.Clamp 
				(_rotationX, minimumVert, maximumVert);
			
			//delta means a change, in time, direction, rotation, etc.
			float delta = Input.GetAxis ("Mouse X") * sensitivityHor;
			
			//increment the rotation angle by delta
			float rotationY = transform.localEulerAngles.y + delta;

			//cheaty cheat
			//_rotationX = 0.0f;
			//create a new Vector3 from the stored roation values
			transform.localEulerAngles = 
				new Vector3 (_rotationX, rotationY, 0);
		}
		
	}
	
	
	
	
	
	
	
	
	
	
	
}