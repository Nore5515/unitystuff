using UnityEngine;
using System.Collections;

public class McQueeryMouth : MonoBehaviour {

	public int hunger;
	public ParticleSystem bom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		Instantiate (bom, other.transform.position, other.transform.rotation);
		Destroy (other);
		hunger--;
	}

}
