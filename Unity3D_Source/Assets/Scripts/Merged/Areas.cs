using UnityEngine;
using System.Collections;

public class Areas : MonoBehaviour {

	public Areas[] otherAreas;
	public bool isActive;
	public int enabler;

	private SpriteRenderer[] childRenderers;

	// Use this for initialization
	void Start () 
	{
		childRenderers = GetComponentsInChildren<SpriteRenderer>();
		Debug.Log (childRenderers.Length);
		//changeVisible (-1);
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public void setVisibleAreas(int var)
	{
		changeVisible (var);
		foreach (Areas myArea in otherAreas)
		{
			myArea.changeVisible(var);
		}
	}

	public void changeVisible(int var)
	{
		switch(var)
		{
		case 0:
			break;
		case 1:
			foreach (SpriteRenderer childRenderer in childRenderers)
			{
				childRenderer.enabled = true;
			}
			break;
		case -1:
			foreach (SpriteRenderer childRenderer in childRenderers)
			{
				childRenderer.enabled = false;
			}
			break;
		}
	}
}
