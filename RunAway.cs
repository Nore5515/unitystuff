using UnityEngine;
using System.Collections;

public class RunAway : MonoBehaviour {
	DaControls ayylmao;

	Transform thisTransform;
	public float minDistance = 10;
	public float fest;
	
	void Awake() {
		thisTransform = transform;
		//thisTransform.position = new Vector3(2, 0, 2);
	}
	
	void Start() {
		
		ayylmao = GameObject.FindGameObjectWithTag("AyyLmao").GetComponent<DaControls>();
	}
	
	void Update() {
		
		
		if(Vector3.Distance(ayylmao.GetTransform().position, thisTransform.position) < minDistance) {
			
			Vector3 direction = thisTransform.position - ayylmao.GetTransform ().position;
			direction.Normalize();
			thisTransform.position = Vector3.MoveTowards(thisTransform.position, direction * minDistance, Time.deltaTime * fest);
		}
	}
}
