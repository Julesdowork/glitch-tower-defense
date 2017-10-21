using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	private ColorBlock selected, unselected;
	private MusicManager musicManager;

	public LevelManager levelManager;
	public Slider volumeSlider;
	public Button easy, medium, hard;

	// Use this for initialization
	void Start ()
	{
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		selected = easy.colors;
		unselected = easy.colors;
		selected.normalColor = new Color(255, 75, 0);
	}

	void Update ()
	{
		musicManager.SetVolume(volumeSlider.value);
		int difficulty = PlayerPrefsManager.GetDifficulty();
		if (difficulty == 1)
		{
			easy.colors = selected;
			medium.colors = unselected;
			hard.colors = unselected;
		}
		else if (difficulty == 3)
		{
			easy.colors = unselected;
			medium.colors = unselected;
			hard.colors = selected;
		}
		else
		{
			easy.colors = unselected;
			medium.colors = selected;
			hard.colors = unselected;
		}
	}

	public void SaveAndExit ()
	{
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		levelManager.LoadLevel("01a Start");
	}

	public void SetDefaults ()
	{
		volumeSlider.value = 0.8f;
		PlayerPrefsManager.SetDifficulty(2);
	}

	public void SetDifficulty (int difficulty)
	{
		PlayerPrefsManager.SetDifficulty(difficulty);
	}
}