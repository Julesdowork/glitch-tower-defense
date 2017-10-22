using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

	private Text countdown;
	private int timer = 5;
	private float startTime;

	// Use this for initialization
	void Start ()
	{
		countdown = GetComponent<Text>();
		countdown.text = "Start";
		startTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float currentTime = Time.timeSinceLevelLoad;
		if ((currentTime - startTime) > timer)
			Destroy(gameObject);
		else if ((currentTime - startTime) > 3)
		{
			countdown.text = "Start";
		}
		else
		{
			int countTime = (int) (4 - (currentTime - startTime));
			countdown.text = countTime.ToString();
		}
	}
}
