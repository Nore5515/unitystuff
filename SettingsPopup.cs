using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{

	[SerializeField]
	private Slider
		speedSlider;

	[SerializeField]
	private InputField
		playerName;




	void Start ()
	{
		speedSlider.value = PlayerPrefs.GetFloat ("speed", 1);
		playerName.text = PlayerPrefs.GetString ("name", name);
	}


	public void Open ()
	{


		gameObject.SetActive (true);
	}


	public void Closed ()
	{

		gameObject.SetActive (false);

	}

	public void OnSubmitName (string name)
	{
		PlayerPrefs.SetString ("name", name);
		Debug.Log (name);


	}

	public void OnSpeedValue (float speed)
	{
		PlayerPrefs.SetFloat ("speed", speed);
		Debug.Log ("speed" + speed);
		Messenger<float>.Broadcast (GameEvent.SPEED_CHANGED, speed);
	}
}
