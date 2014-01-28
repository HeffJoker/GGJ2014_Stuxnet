using UnityEngine;
using System.Collections;

public class CameraWatch : UniversalClick {

	public float watchAngle;
	private SeePlayer finder;

	private bool selected = false;

	// Use this for initialization
	void Start () 
	{
		finder = gameObject.GetComponent<SeePlayer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.eulerAngles = new Vector3(0, 0, watchAngle);

		if (finder.isSee)
		{
			GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
			mainCamera.GetComponent<CameraJump>().resetLevel();
		}
	}

	public override void clickOn()
	{
		selected = true;
	}

	public override void clickAway()
	{
		selected = false;
	}

	void OnGUI()
	{
		if (selected)
		{
			GUI.Box (new Rect((Screen.width / 2) - 300, 20, 600, 80), "Choose camera power state:");
			if (GUI.Button(new Rect((Screen.width / 2) - 100, 40, 80, 30), "On"))
			{
				finder.enabled = true;

				Transform[] children = GetComponentsInChildren<Transform>();

				foreach (Transform child in children)
				{
					child.gameObject.SetActive(false);
				}

				gameObject.SetActive(true);
			}
			if (GUI.Button(new Rect((Screen.width / 2) + 20, 40, 80, 30), "Off"))
			{
				finder.enabled = false;

				Transform[] children = GetComponentsInChildren<Transform>();
				
				foreach (Transform child in children)
				{
					child.gameObject.SetActive(false);
				}

				gameObject.SetActive(true);
			}
		}
	}
}
