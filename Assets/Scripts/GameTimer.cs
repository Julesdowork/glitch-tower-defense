using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	private bool levelOver = false;
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
	}
	
	// Update is called once per frame
	void Update () 
	{
		slider.value = 1 - Time.timeSinceLevelLoad / levelSecs;
		if (Time.timeSinceLevelLoad >= levelSecs && !levelOver)
			HandleWinCondition();
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
}
