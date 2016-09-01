using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class RayShooter : MonoBehaviour
{

	private Camera _camera;


	// Use this for initialization
	void Start ()
	{
		_camera = GetComponent<Camera> ();

		//Lock the cursor
		//Cursor.lockState = CursorLockMode.Locked;
		//hide the cursor from view
		//Cursor.visible = false;
	}

	void OnGUI ()
	{
		int size = 12;
		float posX = _camera.pixelWidth / 2 - size / 2;
		float posY = _camera.pixelHeight / 2 - size / 2;
		//create a GUI label, not a box
		GUI.Label (new Rect (posX, posY, size, size), "*");

	}

	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject ()) {
			//define the middle of the screen
			Vector3 point = 
				new Vector3 (_camera.pixelWidth / 2, 
				             _camera.pixelHeight / 2, 0);

			//creates a Ray that pints in the direction of the camera
			Ray ray = _camera.ScreenPointToRay (point);

			RaycastHit hit; //holds what the ray hit

			//the variable will be filled with what the ray hits...
			if (Physics.Raycast (ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();
				if (target != null) {
					target.reactToHit ();

					Messenger.Broadcast (GameEvent.ENEMY_HIT);
				} else {
					StartCoroutine (SphereIndicator (hit.point));
				}

				//if the ray hits something, run the coroutine below
				StartCoroutine (SphereIndicator (hit.point));

			}
		}
	}

	//This is called, so that other things can run, such as methods
	//This also allows the coroutine to run multiple times in succession
	private IEnumerator SphereIndicator (Vector3 pos)
	{
		GameObject sphere = 
			GameObject.CreatePrimitive (PrimitiveType.Sphere);
		//generates a sphere at the location the ray hit
		sphere.transform.position = pos;

		//wait this amount of time before proceeding 
		//with the next instruction
		yield return new WaitForSeconds (1); 

		//remove the sphere after waiting as defined above
		Destroy (sphere);
	}


}










