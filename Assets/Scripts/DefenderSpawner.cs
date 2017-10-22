using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	private Camera myCamera;
	private GameObject parent;
	private StarDisplay starDisplay;

	// Use this for initialization
	void Start ()
	{
		myCamera = FindObjectOfType<Camera>();
		parent = GameObject.Find("Defenders");
		if (!parent)
			parent = new GameObject("Defenders");
		starDisplay = FindObjectOfType<StarDisplay>();
	}
	
	void OnMouseDown ()
	{
		GameObject defender = TowerButton.selectedDefender;
		int defenderCost = defender.GetComponent<Defender>().starCost;
		if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
		{
			Vector2 rawPos = CalculateWorldPointOfMouseClick();
			Vector2 roundedPos = SnapToGrid(rawPos);
			SpawnDefender(roundedPos, defender);
		}
	}

	Vector2 CalculateWorldPointOfMouseClick ()
	{
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPoint = myCamera.ScreenToWorldPoint(weirdTriplet);
		return worldPoint;
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos)
	{
		float newX = Mathf.Round(rawWorldPos.x);
		float newY = Mathf.Round(rawWorldPos.y);
		return new Vector2(newX, newY);
	}

	void SpawnDefender (Vector2 roundedPos, GameObject obj)
	{
		obj = Instantiate(obj, roundedPos, Quaternion.identity);
		obj.transform.parent = parent.transform;
	}
}
