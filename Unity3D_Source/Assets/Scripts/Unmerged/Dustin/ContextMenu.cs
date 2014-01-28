using UnityEngine;
using System.Collections.Generic;

public class ContextMenu : UniversalClick {
	
	public GameObject Activate;
	public GameObject Deactivate;
	public GameObject Action;

	private GameObject target;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		Activate.GetComponent<SpriteRenderer>().color = Color.white;
		Deactivate.GetComponent<SpriteRenderer>().color = Color.white;
		Action.GetComponent<SpriteRenderer>().color = Color.white;

		RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

		/*if(hit != null)
		{
			GameObject hitObj = hit.transform.gameObject;
			if(hitObj == Activate || hitObj == Deactivate || hitObj == Action)
			{
				hitObj.GetComponent<SpriteRenderer>().color = Color.red;

				if(target
			}
		}*/

	}
}
