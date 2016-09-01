using UnityEngine;
using System.Collections;

public class DoorOpenDevice : MonoBehaviour
{

	[SerializeField]
	private Vector3
		dPos;

	private bool _open;

	private float resetTime;
	void Awake ()
	{
		resetTime = 0.0f;
	}


	public void Operate ()
	{
		if (_open && resetTime <= Time.time) {
			Vector3 pos = transform.position - dPos;

			iTween.MoveTo (gameObject, pos, 2.0f);
			resetTime = Time.time + 2.1f;

			_open = false;
			//transform.position = pos;

		} else if (!_open && resetTime <= Time.time) {
			Vector3 pos = transform.position + dPos;

			iTween.MoveTo (gameObject, pos, 2.0f);
			resetTime = Time.time + 2.1f;

			_open = true;

			//transform.position = pos;
		}


	}




	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
