using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{

	
	[SerializeField]
	private Text
		scoreLabel;
		
	[SerializeField]
	private SettingsPopup
		settingsPopup;

	private int _score;


	void Awake ()
	{

		Messenger.AddListener (GameEvent.ENEMY_HIT, OnEnemyHit);
	}
	void OnDestroy ()
	{

		Messenger.RemoveListener (GameEvent.ENEMY_HIT, OnEnemyHit);
	}


	// Use this for initialization
	void Start ()
	{
	
		settingsPopup.Closed ();



	}
	
	// Update is called once per frame
	void Update ()
	{
	
		_score = 0;
		scoreLabel.text = _score.ToString ();




	}
	public void OnEnemyHit ()
	{
		_score += 1;

		scoreLabel.text = _score.ToString ();
	}
	public void OnOpenSettings ()
	{
		settingsPopup.Open ();
		Debug.Log ("Open Settings");
	}
	public void OnPointerDown ()
	{
		Debug.Log ("Pointer Down");
	}
}
