using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	private AudioSource audioSource;

	public AudioClip[] levelMusicChangeArray;

	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
		Debug.Log("Don't destroy on load: " + name);
	}
		
	void OnEnable ()
	{
		// Tell the function OnSceneLoaded() to start listening for scene changes
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
		Debug.Log("Playing Clip:" + thisLevelMusic);

		// If there's some music attached and it's not the one that's already playing
		if (thisLevelMusic && audioSource.clip != thisLevelMusic)
		{
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void SetVolume(float value)
	{
		audioSource.volume = value;
	}
}
