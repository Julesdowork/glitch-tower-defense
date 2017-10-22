using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed, damage;

	// Update is called once per frame
	void Update ()
	{
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Attacker attacker = col.gameObject.GetComponent<Attacker>();
		Health health = col.gameObject.GetComponent<Health>();

		if (attacker && health)
		{
			health.DealDamage(damage);
			Destroy(gameObject);
			Debug.Log("Collided with attacker");
		}
	}
}
