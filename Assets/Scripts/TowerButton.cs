using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour {

	private StarDisplay starDisplay;
	private TowerButton[] buttonArray;
	private Text costText;

	public static GameObject selectedDefender;
	public GameObject defenderPrefab;

	// Use this for initialization
	void Start ()
	{
		//buttonArray = GameObject.FindObjectsOfType<TowerButton>();
		costText = GetComponentInChildren<Text>();
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
		starDisplay = FindObjectOfType<StarDisplay>();
	}

	void Update ()
	{
		if (starDisplay.stars >= defenderPrefab.GetComponent<Defender>().starCost)
		{
			if (selectedDefender == defenderPrefab)
				GetComponent<SpriteRenderer>().color = Color.yellow;
			else
				GetComponent<SpriteRenderer>().color = Color.white;
		}
		else
			GetComponent<SpriteRenderer>().color = Color.black;
	}
	
	void OnMouseDown ()
	{
		selectedDefender = defenderPrefab;
	}
}
