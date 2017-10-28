using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject countdown;
	public GameObject canvas;

	public void StartCountdown()
	{
		GameObject countdownPrefab = Instantiate(countdown);
		countdown.transform.parent = canvas.transform;
	}
}
