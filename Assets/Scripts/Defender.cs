using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

	private StarDisplay starDisplay;

	public int starCost;

	// Use this for initialization
	void Start ()
	{
		starDisplay = FindObjectOfType<StarDisplay>();	
	}

	public void AddStars ()
	{
		starDisplay.AddStars(50);
	}
}
