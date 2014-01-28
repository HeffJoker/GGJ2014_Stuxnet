using UnityEngine;
using System.Collections;

public class SwitchInput : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = Input.mousePosition;

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);

			if(hit != null)
			{
				Vector3 position = hit.transform.position;
				hit.collider.gameObject.transform.position = player.transform.position;
				player.transform.position = position;
			}
		}
	}
}
