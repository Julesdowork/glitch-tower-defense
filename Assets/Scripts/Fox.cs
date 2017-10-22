using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		GameObject obj = col.gameObject;

		// Leave method if not colliding with a defender
		if (!obj.GetComponent<Defender>())
			return;

		if (obj.GetComponent<Stone>())
			anim.SetTrigger("jumpTrigger");
		else
		{
			anim.SetBool("isAttacking", true);
			attacker.Attack(obj);
		}
	}
}
