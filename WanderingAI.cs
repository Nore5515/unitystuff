using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour
{
	private bool _alive = true;

	public float speed = 3.0f;

	public float obsticleRange = 5.0f;

	[SerializeField]
	private GameObject
		fireballPrefab;

	private GameObject _fireball;


	public const float baseSpeed = 3.0f;

	private void OnSpeedChanged (float value)
	{
		speed = baseSpeed * value;


	}
	void Awake ()
	{
		Messenger<float>.AddListener (GameEvent.SPEED_CHANGED, OnSpeedChanged);
		speed = PlayerPrefs.GetFloat ("speed", 1);
	}
	void OnDestroy ()
	{
		Messenger<float>.RemoveListener (GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_alive) {
			transform.Translate (0, 0, speed * Time.deltaTime);

			Ray ray = new Ray (transform.position, transform.forward);

			RaycastHit hit;


			if (Physics.SphereCast (ray, 0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.GetComponent<PlayerCharactor> ()) {
					if (_fireball == null) {
						_fireball = Instantiate (fireballPrefab) as GameObject;

						_fireball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);

						_fireball.transform.rotation = transform.rotation;
					}
				} else if (hit.distance < obsticleRange) {
					float angle = Random.Range (-110, 110);

					transform.Rotate (0, angle, 0);
				}
			}
		}
	}
	public void SetAlive (bool alive)
	{
		_alive = alive;
	}
}
