using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

	private StarDisplay starDisplay;

	// Use this for initialization
	void Start ()
	{
		starDisplay = FindObjectOfType<StarDisplay>();	
	}

	public void AddStars()
	{
		starDisplay.AddStars(50);
		Destroy(this);
	}
}
