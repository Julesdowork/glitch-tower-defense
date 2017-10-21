using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";		// level_unlocked_1 for Level 1

	public static void SetMasterVolume (float volume)
	{
		if (volume >= 0f && volume <= 1f)
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		else
			Debug.LogError("Master volume out of range");
	}

	public static float GetMasterVolume ()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel (int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1)
		{
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);	// Use 1 for true
		}
		else
		{
			Debug.LogError("Trying to unlock level not in build manager.");
		}
	}

	public static bool IsLevelUnlocked (int level)
	{
		if (level < 0 || level >= SceneManager.sceneCountInBuildSettings)
		{
			Debug.LogError("Trying to check level not in build manager.");
			return false;
		}
		else
			return PlayerPrefs.GetInt(LEVEL_KEY + level) == 1;
	}

	public static void SetDifficulty (int difficulty)
	{
		if (difficulty >= 1 && difficulty <= 3)
			PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
		else
			Debug.LogError("Difficulty level not in range.");
	}

	public static int GetDifficulty ()
	{
		return PlayerPrefs.GetInt(DIFFICULTY_KEY);
	}
}
