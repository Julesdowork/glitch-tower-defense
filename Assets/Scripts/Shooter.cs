using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	private Animator animator;
	private GameObject projectileParent;
	private Spawner myLaneSpawner;

	public GameObject projectile, gun;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator>();
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent)
			projectileParent = new GameObject("Projectiles");
		SetMyLaneSpawner();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (IsAttackerAheadInLane())
			animator.SetBool("isAttacking", true);
		else
			animator.SetBool("isAttacking", false);
	}

	void FireGun ()
	{
		GameObject newProjectile = Instantiate(projectile);
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

	bool IsAttackerAheadInLane ()
	{
		// Are there attackers in this lane?
		if (myLaneSpawner.transform.childCount <= 0)
			return false;
		// Are they ahead of the shooter?
		foreach (Transform attacker in myLaneSpawner.transform)
		{
			if (attacker.transform.position.x > transform.position.x)
				return true;
		}
		return false;
	}

	void SetMyLaneSpawner ()
	{
		Spawner[] spawners = FindObjectsOfType<Spawner>();
		foreach (Spawner spawner in spawners)
		{
			if (spawner.transform.position.y == transform.position.y)
			{
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError("Spawner not found in this lane");
	}
}
