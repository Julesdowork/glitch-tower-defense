using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start ()
	{
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	public void StopGame ()
	{
		levelManager.LoadLevel("01a Start");
	}
}
