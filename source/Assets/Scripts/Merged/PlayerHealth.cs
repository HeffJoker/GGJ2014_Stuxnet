using UnityEngine;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour {

	private List<GameObject> healthSprites = new List<GameObject>();
	// Use this for initialization
	void Start () {

		GameObject newSprite;

		for(int i = 0; i < transform.childCount; ++i)
		{
			healthSprites.Add(transform.GetChild(i).gameObject);
		}

		healthSprites.Sort((obj1, obj2) => { return obj1.transform.position.x.CompareTo(obj2.transform.position.x); });
		/*for(int i = 0; i < MaxLives; ++i)
		{
			newSprite = Instantiate(HealthPrefab) as GameObject;
			newSprite.transform.position = transform.position + new Vector3(HealthSpacing * i, 0, 0);
			healthSprites.Push(newSprite);
		}*/
	}

	void TakeDamage(int damage)
	{
		if(healthSprites.Count > 0)
		{
			GameObject delObj = healthSprites[healthSprites.Count - 1];
			healthSprites.Remove(delObj);

			if(delObj != null)
				Destroy(delObj);
		}

		if(damage <= 0)
			; // Start Level over
	}
}
