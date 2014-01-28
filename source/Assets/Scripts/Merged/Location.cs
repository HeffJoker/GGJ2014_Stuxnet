using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Location : MonoBehaviour {

	public float xPos;
	public float yPos;
	public float zDepth;
	public string myName = "";
	public float multiplier;
	public float xPlus;
	public float yPlus;

	void Update()
	{
		transform.position = new Vector3((xPos + xPlus)*multiplier, (yPos+yPlus)*multiplier, zDepth);
		transform.name = myName + " : " + xPos.ToString() + "," + yPos.ToString();
	}
}
