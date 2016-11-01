using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class KineticBlast : MonoBehaviour {

	GameObject cube;
	public float rateOfScale;
	private bool enabled;
	private bool giantMode;

	public float giantMultiplier;
	public float kineticBlastSize;

	private Vector3 playerStayAway;

	// Use this for initialization
	void Start () {
		cube = null;
		enabled = false;
		giantMode = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (this.name == "Player") {
			//Debug.Log("pls harambe stop: " + this.name);


			CapsuleCollider meSphere = this.GetComponent<CapsuleCollider> ();

			if (Input.GetKeyDown (KeyCode.Q)) {
				giantMode = !giantMode;
				meSphere.radius = 1.0f;
				meSphere.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			}
				
			//when middle mouse button is pressed
			if (Input.GetMouseButtonDown (2)) {
				//toggle enabled
				enabled = !enabled;
				if (giantMode) {
					if (enabled) {
						meSphere.transform.localScale = new Vector3 (giantMultiplier, giantMultiplier, giantMultiplier);
					} else {
						meSphere.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
					}
				} else {
					if (enabled) {
						meSphere.radius = kineticBlastSize;
					} else {
						meSphere.radius = 1.0f;
					}
				}
			}

		}
	}

	

	public void kineticBlastOn(GameObject user){
		BoxCollider cal = user.GetComponent<BoxCollider> ();
		playerStayAway = cal.transform.localScale;
		cal.transform.localScale = new Vector3 (giantMultiplier, giantMultiplier, giantMultiplier);
	}
	public void kineticBlastOff(GameObject user){
		BoxCollider cal = user.GetComponent<BoxCollider> ();
		cal.transform.localScale = playerStayAway;
	}
}
