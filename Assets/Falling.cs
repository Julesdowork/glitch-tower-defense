using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {

	private float startY = 7f;
	private StarDisplay starDisplay;

	public float speed = 0.6f;

	// Use this for initialization
	void Start ()
	{
		float startX = Random.Range(1f, 9f);
		transform.position = new Vector3(startX, startY, 0);
		starDisplay = FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);
		if (transform.position.y <= -0.7f)
			Destroy(gameObject);
	}

	void OnMouseDown ()
	{
		starDisplay.AddStars(50);
		Destroy(gameObject);
	}
}
