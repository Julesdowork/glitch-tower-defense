using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

	private bool isRunning;
	private float timer = 3;
	private Text countdown;

	// Use this for initialization
	void Start ()
	{
		countdown = GetComponent<Text>();
		countdown.text = "";
		isRunning = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isRunning)
		{
			timer -= Time.deltaTime;
			countdown.text = ((int) timer + 1f).ToString();
			if (timer <= 0.0f)
			{
				countdown.text = "Start";
				Invoke("DestroyTimer", 2f);
			}
		}
	}

	void DestroyTimer ()
	{
		Destroy(gameObject);
	}
}
