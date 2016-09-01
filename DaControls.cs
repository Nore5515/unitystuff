using UnityEngine;
using System.Collections;

public class DaControls : MonoBehaviour {
	/*public float gottagofast;
	private BoxCollider bexc;
	private Transform thisTransform; 

	// Use this for initialization
	void Start () {
		bexc = GetComponent<BoxCollider> ();
	}
	void Transform GetTransform(){
		bexc.transform.
	}
	
	// Update is called once per frame
	void Update () {
		float moveX = Input.GetAxis("Horizontal");
		float moveY = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveX, 0.0f, moveY);
		bexc.transform.Translate(movement * gottagofast);

	}*/
	private Transform thisTransform;
	public float gottagofast;
	
	void Awake() {
		thisTransform = transform;    
	}
	
	public Transform GetTransform() {
		return thisTransform;    
	}
	
	void Update() {
		
		float keyboardX = Input.GetAxis("Horizontal");
		float keyboardY = Input.GetAxis("Vertical");
		
		var newPos = thisTransform.position + new Vector3(keyboardX, 0, keyboardY);    
		thisTransform.position = Vector3.MoveTowards(thisTransform.position, newPos, Time.deltaTime * gottagofast);
	}
}
