using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture2D menuBackground;
	public float calcWidth;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		if (Input.GetMouseButtonDown(1))
		{
			Application.LoadLevel("Tutorial1");
		}
	}

	void OnGUI()
	{
		calcWidth = Screen.height * 4 / 3;
		GUI.DrawTexture(new Rect((Screen.width - calcWidth) / 2, 0, calcWidth, Screen.height), menuBackground);

		/*if (GUI.Button (new Rect((Screen.width) / 2, (Screen.height / 3) * 2, Screen.width / 8, Screen.height / 18), "Thomas's Level"))
		{
			Application.LoadLevel("TD_level");
		}

		if (GUI.Button (new Rect((Screen.width) / 2, ((Screen.height / 3) * 2) + Screen.height / 16, Screen.width / 8, Screen.height / 18), "Michael's Level"))
		{
			Application.LoadLevel("MichaelLevel");
		}*/

		if (GUI.Button (new Rect(((Screen.width) / 2), (Screen.height / 3) * 2, Screen.width / 8, Screen.height / 8), "Play Game"))
		{
			Application.LoadLevel("mario_level1");
		}

		if (GUI.Button (new Rect(((Screen.width) / 2) + Screen.width / 6, (Screen.height / 3) * 2, Screen.width / 8, Screen.height / 8), "Tutorial"))
		{
			Application.LoadLevel("Tutorial1");
		}

		if (GUI.Button (new Rect(calcWidth - ((Screen.width) / 12), 10, Screen.width / 16, Screen.height / 16), "Close"))
		{
			Application.Quit();
		}
	}
}
