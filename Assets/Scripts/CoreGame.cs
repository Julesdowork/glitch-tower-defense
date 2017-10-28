using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreGame : MonoBehaviour {

	private Animator cameraAnim;
	private Spawner[] spawners;

	public GameObject countdown;
	public GameObject starGeneratorPrefab;
	public GameTimer timer;
	public Camera gameCamera;

	void Start ()
	{
		cameraAnim = gameCamera.GetComponent<Animator>();
		spawners = FindObjectsOfType<Spawner>();
		cameraAnim.SetTrigger("panTrigger");
		Invoke("StartCountdown", 6f);
		Invoke("StartGameTimer", 11f);
		Invoke("StartFallingStars", 11f);
		Invoke("ActivateSpawners", 30f);
	}

	void ActivateSpawners ()
	{
		foreach (Spawner spawner in spawners)
			spawner.Activate();
	}

	void StartCountdown ()
	{
		Instantiate(countdown, this.transform.parent);
	}

	void StartGameTimer ()
	{
		timer.StartTimer();
	}

	void StartFallingStars ()
	{
		Instantiate(starGeneratorPrefab, this.transform.parent);
	}
}
