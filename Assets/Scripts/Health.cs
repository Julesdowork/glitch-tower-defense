using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health;

	public void DealDamage (float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			// Optionally trigger "Die" animation
			DestroyObject(gameObject);
		}
	}
}
