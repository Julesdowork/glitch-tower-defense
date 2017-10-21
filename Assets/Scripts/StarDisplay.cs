using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private int stars = 50;
	private Text starText;

	// Use this for initialization
	void Start ()
	{
		starText = GetComponent<Text>();
		UpdateDisplay();
	}

	public void UpdateDisplay ()
	{
		starText.text = stars.ToString();	
	}

	public void AddStars (int amount)
	{
		stars += amount;
		UpdateDisplay();
	}
}
