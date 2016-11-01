using UnityEngine;
using System.Collections;

public class BossScorpion : MonoBehaviour {

	public GameObject player;
	public float closingRange;
	private KineticBlast kb;
	private bool isBlastin;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		kb = this.GetComponent<KineticBlast> ();
		isBlastin = false;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (this.transform.position, player.transform.position);

		if (distance <= closingRange && isBlastin == false) {
			StartCoroutine (delayForKBlast (3.0f));
			isBlastin = true;
		}
		

	}

	IEnumerator delayForKBlast(float waitTime){
		Attack ack = this.GetComponent<Attack> ();
		float tempFast = ack.getFast ();
		ack.setFast (0.0f);
		yield return new WaitForSeconds (waitTime);
		Debug.Log ("child: " + this.transform.GetChild (0).gameObject);
		kb.kineticBlastOn (this.transform.GetChild(0).gameObject);
		Debug.Log ("tempFast: " + tempFast);
		ack.setFast (tempFast);
		yield return new WaitForSeconds (waitTime * 2);
		kb.kineticBlastOff (this.transform.GetChild(0).gameObject); 
		isBlastin = false;
	}

}
