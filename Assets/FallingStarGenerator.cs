using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStarGenerator : MonoBehaviour {

	public GameObject fallingStar;

	// Use this for initialization
	void Start ()
	{
		InvokeRepeating("GenerateFallingStar", 5f, 30f);
	}

	private void GenerateFallingStar()
	{
		Instantiate(fallingStar);
	}
}
