using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator>();	
	}
	
	void OnTriggerStay2D (Collider2D col)
	{
		Attacker attacker = col.gameObject.GetComponent<Attacker>();
		if (attacker)
			animator.SetTrigger("underAttackTrigger");
	}
}
