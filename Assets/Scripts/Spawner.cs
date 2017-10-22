using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabs;
	
	// Update is called once per frame
	void Update ()
	{
		foreach (GameObject thisAttacker in attackerPrefabs)
		{
			if (IsTimeToSpawn(thisAttacker))
				Spawn(thisAttacker);
		}
	}

	bool IsTimeToSpawn (GameObject obj)
	{
		Attacker attacker = obj.GetComponent<Attacker>();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSec = 1 / meanSpawnDelay;
		if (Time.deltaTime > meanSpawnDelay)
			Debug.LogWarning("Spawn rate capped by frame rate.");
		float threshold = spawnsPerSec * Time.deltaTime / 5;
		return Random.value < threshold;
	}

	void Spawn (GameObject obj)
	{
		GameObject myObject = Instantiate(obj);
		myObject.transform.parent = transform;
		myObject.transform.position = transform.position;
	}
}
