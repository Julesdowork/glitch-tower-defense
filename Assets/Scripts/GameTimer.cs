using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	private bool isRunning;
	private bool levelOver = false;
	private float startTime;
	private float currentTime;
	private AudioSource audioSource;
	private GameObject winLabel;
	private LevelManager levelManager;
	private Slider slider;

	public float levelSecs = 100;

	// Use this for initialization
	void Start ()
	{
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = FindObjectOfType<LevelManager>();
		winLabel = GameObject.Find("Win Label");
		winLabel.SetActive(false);
		isRunning = false;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isRunning)
		{
			currentTime = Time.time - startTime;
			Debug.Log(currentTime);
			slider.value = 1 - currentTime / levelSecs;
			if (currentTime >= levelSecs && !levelOver)
				HandleWinCondition();
		}
	}

	// Destroys all objects with "Destroy on Win" tag
	void DestroyAllTaggedObjects ()
	{
		GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Destroy on Win");
		foreach (GameObject taggedObject in taggedObjects)
			Destroy(taggedObject);
	}

	void HandleWinCondition ()
	{
		isRunning = false;
		DestroyAllTaggedObjects();
		audioSource.Play();
		winLabel.SetActive(true);
		Invoke("LoadNextLevel", audioSource.clip.length);
		levelOver = true;
	}

	void LoadNextLevel ()
	{
		levelManager.LoadNextLevel();
	}

	public void StartTimer ()
	{
		isRunning = true;
		startTime = Time.time;
	}
}
