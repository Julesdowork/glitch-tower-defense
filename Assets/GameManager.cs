using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Camera mainCamera;
	public Text countdown;

	// Use this for initialization
	void Start ()
	{
		countdown.gameObject.SetActive(false);
		mainCamera.GetComponent<Animator>().SetTrigger("panTrigger");
		countdown.gameObject.SetActive(true);
	}
}
