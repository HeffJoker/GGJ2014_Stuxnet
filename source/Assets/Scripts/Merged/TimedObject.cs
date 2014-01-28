using UnityEngine;
using System.Collections;

public class TimedObject : UniversalClick {

	public float PossessTime = 5f;

	public override void clickOn()
	{
		PossessTimer timer = Camera.main.GetComponentInChildren<PossessTimer>();

		timer.MaxPossessTime = PossessTime;
		timer.Reset();
		timer.Show(transform);
	}
	
	public override void clickAway()
	{
		PossessTimer timer = Camera.main.GetComponentInChildren<PossessTimer>();
		timer.Hide();
	}

}
