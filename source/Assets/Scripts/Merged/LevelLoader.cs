using UnityEngine;
using System.Collections;

public class LevelLoader : UniversalClick {

	public string LevelToLoad = string.Empty;

	public override void clickOn ()
	{
		if(!string.IsNullOrEmpty(LevelToLoad))
			Application.LoadLevel(LevelToLoad);
	}
}
