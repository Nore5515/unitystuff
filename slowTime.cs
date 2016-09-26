using UnityEngine;
using System.Collections;

public class slowTime : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Q))
		{
			Time.timeScale = 0.25f;
		}

		if (Input.GetKeyUp (KeyCode.Q))
		{
			Time.timeScale = 1;
		}
	}
}
