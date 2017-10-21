using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;

	[Tooltip("Average number of seconds between appearances")]
	public float seenEverySeconds;

	// Use this for initialization
	void Start ()
	{
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);	
	}

	public void SetSpeed (float speed)
	{
		currentSpeed = speed;
	}
}
