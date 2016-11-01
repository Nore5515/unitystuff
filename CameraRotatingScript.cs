﻿using UnityEngine;
using System.Collections;

public class CameraRotatingScript : MonoBehaviour {
	
	public Camera playerCam;
	public GameObject rotatingPlayer;
	
	public float minimumVert;
	public float maximumVert;
	
	public float sensitivityVert;
	public float sensitivityHor;
	
	private float _rotationX = 0.0f;
	private float _rotationY = 0.0f;
	
	
	// Use this for initialization
	void Start () {
		playerCam = Camera.main;
		//UnityEngine.Cursor.visible = false;
		UnityEngine.Cursor.lockState = UnityEngine.CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		
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