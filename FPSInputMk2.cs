using UnityEngine;
using System.Collections;

public class FPSInputMk2 : MonoBehaviour {

	public Vector3 moveDirection;
	public CharacterController _charController;
	public float speed;
	public Object theshoot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//capture the player's input
		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"),
			0.0f, Input.GetAxis ("Vertical"));

		//use the players input to change the direction of the transform
		//of the object this script is attached to (the player)
		moveDirection = transform.TransformDirection (moveDirection);

		//add how fast to move
		moveDirection *= speed;

		_charController.Move (moveDirection * Time.deltaTime);

		if (Input.GetMouseButton (0)) {
			Vector3 swwod;
			swwod = new Vector3 (this.transform.forward.x, this.transform.forward.y, this.transform.forward.z + 5.0f);
			Instantiate(theshoot, swwod, this.transform.rotation);
		}
	}
}
