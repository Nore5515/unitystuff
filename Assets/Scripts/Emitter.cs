using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {
	
	public int particlesPerSec = 100;
	public ParticleSystem fireBreath;
	
	// Use this for initialization
	void Start () 
	{
		fireBreath = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton (0))
		{
			fireBreath.Emit((int)(particlesPerSec * Time.deltaTime));
		}
	}
}