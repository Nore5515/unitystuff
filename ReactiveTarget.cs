using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour
{


	public void reactToHit ()
	{

		WanderingAI behaivor = GetComponent<WanderingAI> ();

		if (behaivor != null) {
			behaivor.SetAlive (false);
		}

		StartCoroutine (Die ());
	}

	private IEnumerator Die ()
	{
		this.transform.Rotate (-75, 0, 0);

		yield return new WaitForSeconds (1.5f);

		Destroy (this.gameObject);
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
