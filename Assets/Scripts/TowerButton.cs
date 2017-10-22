using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour {

	private TowerButton[] buttonArray;
	private Text costText;

	public static GameObject selectedDefender;
	public GameObject defenderPrefab;

	// Use this for initialization
	void Start ()
	{
		buttonArray = GameObject.FindObjectsOfType<TowerButton>();
		costText = GetComponentInChildren<Text>();
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}
	
	void OnMouseDown ()
	{
		foreach (TowerButton thisButton in buttonArray)
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
