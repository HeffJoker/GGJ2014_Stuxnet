using UnityEngine;
using System.Collections;

public class Box : UniversalClick {

	public Areas myArea;
	public string optionalText1 = "";
	public string optionalText2 = "";

	private bool selected = false;

	// Use this for initialization
	void Start () 
	{
		//myArea = transform.parent.parent.GetComponent<Areas>();
	}

	public override void clickOn()
	{
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		selected = true;
	}

	public override void clickAway()
	{
		selected = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnGUI()
	{
		if (selected)
		{
			if (optionalText1 != "")
			{
				GUI.Box(new Rect((Screen.width / 2) - 300, Screen.height - 100, 600, 30), optionalText1);
			}

			if (optionalText2 != "")
			{
				GUI.Box(new Rect((Screen.width / 2) - 300, Screen.height - 70, 600, 30), optionalText2);
			}
		}
	}
}
