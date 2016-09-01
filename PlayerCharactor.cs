using UnityEngine;
using System.Collections;

public class PlayerCharactor : MonoBehaviour
{

	private int _health;

	// Use this for initialization
	void Start ()
	{

		_health = 5;
	}
	public void Hurt (int damage)
	{
		_health -= damage;
		Debug.Log ("Player health: " + _health);
	}
	// Update is called once per frame
	void Update ()
	{
	
	}
}
