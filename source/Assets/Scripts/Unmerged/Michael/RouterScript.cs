using UnityEngine;
using System.Collections;

public class RouterScript : UniversalClick {

	public string nextLevel = "MainMenu";

	// Use this for initialization
	void Start () 
	{
	
	}

	public override void clickOn()
	{
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		Application.LoadLevel(nextLevel);
	}

	public override void clickAway()
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
