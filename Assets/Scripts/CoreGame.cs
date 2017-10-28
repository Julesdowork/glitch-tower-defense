using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreGame : MonoBehaviour {

	private Animator cameraAnim;

	public GameObject countdown;
	public Camera camera;

	void Start ()
	{
		Debug.Log("In Start()");
		cameraAnim = camera.GetComponent<Animator>();
		cameraAnim.SetTrigger("panTrigger");
	}

	public void StartCountdown()
	{
		GameObject countdownPrefab = Instantiate(countdown, this.transform);
	}
}
