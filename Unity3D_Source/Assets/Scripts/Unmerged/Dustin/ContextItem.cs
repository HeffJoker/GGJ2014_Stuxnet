using UnityEngine;
using System.Collections.Generic;

public class ContextItem : UniversalClick {
	
	public string[] Contexts;
	public Vector3 Offset;
	public Vector2 ButtonSize;

	private GameObject target;
	private bool isVisible = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public override void clickOn ()
	{
		Camera.main.BroadcastMessage("ShowMenu", gameObject);
	}

	public override void clickAway()
	{
		Camera.main.BroadcastMessage("HideMenu");
	}
}
