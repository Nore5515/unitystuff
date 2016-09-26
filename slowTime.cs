using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class slowTime : MonoBehaviour {

	public float sloSpeed = 0.1f;
	public float totalTime = 10f;
	public float recoveryRate = 0.5f;
	//public Slider EnergyBar;

	private float elapsed = 0f;
	private bool isSlow = false;

	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Q") && elapsed < totalTime)
		{
			SetSpeed (sloSpeed);
		}

		if (Input.GetButtonUp ("Q"))
		{
			SetSpeed (1f);
		}

		if (isSlow)
		{
			elapsed += Time.deltaTime / sloSpeed;

			if (elapsed >= totalTime)
			{
				SetSpeed (1f);
			}
		} 
		else
		{
			elapsed -= Time.deltaTime * recoveryRate;
			elapsed = Mathf.Clamp (elapsed, 0, totalTime);
		}

		float remainingtime = (totalTime - elapsed) / totalTime;
		//EnergyBar.value = remainingtime;
	}

	private void SetSpeed (float speed)
	{
		Time.timeScale = speed;
		Time.fixedDeltaTime = 0.02f * speed;
		isSlow = !(speed >= 1.0f);
	}
}
