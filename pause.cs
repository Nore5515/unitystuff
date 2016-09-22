using System;
using UnityEngine;

public class pause : MonoBehaviour
{
	public GameObject pauseMenu;

	public bool isPaused;

	public Texture resume;

	void Start ()
	{
		isPaused = false;
	}

	void Update ()
	{
		if (isPaused)
		{
			PauseGame (true);
		} else {
			PauseGame (false);
		}

		if (Input.GetButtonDown ("Cancel")) 
		{
			SwitchPause();
		}
	}

	void PauseGame (bool state)
	{
		if (state)
		{
			Time.timeScale = 0.0f; //paused
		}

		else
		{
			Time.timeScale = 1.0f; //unpaused
		}

		pauseMenu.SetActive (state);
	}

	public void SwitchPause()
	{
		if (isPaused)
		{
			isPaused = false;
		}

		else {
			isPaused = true;
		}
	}

	void OnGUI()
	{
		if (GUILayout.Button (resume))
		{
			isPaused = false;
		}
	}
}