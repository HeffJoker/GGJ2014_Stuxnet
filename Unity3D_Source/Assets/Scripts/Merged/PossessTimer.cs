using UnityEngine;
using System.Collections;

public class PossessTimer : MonoBehaviour {

	[HideInInspector]
	public float MaxPossessTime = 5f;
	public Vector3 GUIOffset;

	public GameObject Background;
	public GameObject Fill;

	private SpriteRenderer background;
	private SpriteRenderer fill;

	private float currTime;
	private Vector3 startScale;

	// Use this for initialization
	void Start () {
		this.background = Background.GetComponent<SpriteRenderer>();
		this.fill = Fill.GetComponent<SpriteRenderer>();

		startScale = fill.gameObject.transform.localScale;
		Reset();	
	}
	
	// Update is called once per frame
	void Update () {

		if(background.enabled && fill.enabled)
		{
			currTime -= Time.deltaTime;
			fill.transform.localScale = new Vector3(currTime / MaxPossessTime * startScale.x, startScale.y, startScale.z);
			fill.color = Color.Lerp(Color.red, Color.green, currTime / MaxPossessTime);

			if(currTime <= 0)
			{
				Camera.main.BroadcastMessage("TakeDamage", 1);
				Reset(); //Do Stuff
			}
		}
	}

	public void Reset()
	{
		currTime = MaxPossessTime;
		fill.transform.localScale = startScale;
	}

	public void Show(Transform trans)
	{
		background.enabled = true;
		fill.enabled = true;

		background.transform.position = fill.transform.position = trans.position + GUIOffset;
	}

	public void Hide()
	{
		background.enabled = false;
		fill.enabled = false;
	}
}
