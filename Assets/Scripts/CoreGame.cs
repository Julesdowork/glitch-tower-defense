using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreGame : MonoBehaviour {

	private Animator cameraAnim;

	public GameObject countdown;
	public GameObject starGeneratorPrefab;
	public GameTimer timer;
	public Camera gameCamera;

	void Start ()
	{
		Debug.Log("In Start()");
		cameraAnim = gameCamera.GetComponent<Animator>();
		cameraAnim.SetTrigger("panTrigger");
		Invoke("StartCountdown", 6f);
		Invoke("StartGameTimer", 11f);
		Invoke("StartFallingStars", 11f);
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
