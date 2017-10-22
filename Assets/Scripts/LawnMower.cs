using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMower : MonoBehaviour {

	private bool activated;
	private float speed = 2f;

	// Use this for initialization
	void Start ()
	{
		activated = false;
	}

	void Update ()
	{
		if (activated)
			transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (!activated)
		{
			activated = true;
			Debug.Log("Activated by " + col.name);
			DestroyObject(col.gameObject);
		}
		else
			DestroyObject(col.gameObject);
	}
}
