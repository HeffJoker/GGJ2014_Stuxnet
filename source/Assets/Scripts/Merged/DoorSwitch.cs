using UnityEngine;
using System.Collections;

public class DoorSwitch : UniversalClick {

	public GameObject Door;

	public override void clickOn ()
	{
		FlipSwitch(); 
	}

	public void FlipSwitch()
	{
		Door.SendMessage("Slide");
	}
}
