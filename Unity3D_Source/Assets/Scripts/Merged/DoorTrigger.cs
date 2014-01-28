using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class DoorTrigger : MonoBehaviour {

	public GameObject Door;
	private bool doorOpened = false;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject != null && !doorOpened)
		{
			Door.SendMessage("Slide");
			doorOpened = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.gameObject != null && doorOpened)
		{
			Door.SendMessage("Slide");
			doorOpened = false;
		}		
	}
}
