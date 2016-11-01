using UnityEngine;
using System.Collections;

public class MayMaterialChanger : MonoBehaviour {
	Renderer rend;
	public Material newMaterialRef;
	public Material myOldMaterial;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		Material myNewMaterial = new Material( "MAYTRIX" );
		Material myOldMaterial = new Material( "MAYFACE" );
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			rend.material = newMaterialRef;
		} else {
			rend.material = myOldMaterial;
		}
	}
}
