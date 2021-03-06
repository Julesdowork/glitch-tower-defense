﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevel;

	void Start ()
	{
		if (autoLoadNextLevel > 0)
			Invoke ("LoadNextLevel", autoLoadNextLevel);
	}

	public void LoadLevel (string name)
	{
		Debug.Log("Level load requested for: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest ()
	{
		Debug.Log("Quit requested");
		Application.Quit();
	}

	public void LoadNextLevel ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
