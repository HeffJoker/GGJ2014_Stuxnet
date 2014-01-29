using UnityEngine;
using System.Collections;
using System;

public class CameraJump : MonoBehaviour {

	public Transform followMe;
	public Areas currentArea;
	public Texture2D myMouse;
	//public float mouseSensitivity;
	//public UniversalClick lastClicked;

	private bool isFirst = true;
	private LayerMask jumpableEntities;
	private Vector3 levelBegin;
	private Transform firstObject;
	private GameObject hitObject;
	private float flyTime = 0;
	private Vector2 flyFrom;
	private float multiplier;

	// Use this for initialization
	void Start () 
	{
		jumpableEntities = LayerMask.NameToLayer ("Jumpable");
		Debug.Log (jumpableEntities.value);

		jumpableEntities = 1 << 0;

		levelBegin = transform.position;
		firstObject = followMe;

		if (followMe.tag == "actionJump")
		{
			hitObject = followMe.gameObject;
			hitObject.SendMessage("clickOn");
		}

		Debug.Log (Mathf.Cos (Mathf.PI/2));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("MainMenu");
		}

		//transform.position = new Vector3(transform.position.x + (Input.GetAxis("Mouse X") / mouseSensitivity), transform.position.y + (Input.GetAxis("Mouse Y") / mouseSensitivity), -10);

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
		if(hit.collider != null)
		{
			RaycastHit2D objectsBetween = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y), new Vector2(hit.transform.position.x, hit.transform.position.y), jumpableEntities);
			if (objectsBetween.collider == null)
			{
				if (Input.GetMouseButtonDown(0))
				{
					flyTime = Time.fixedTime + 0.5f;
					flyFrom = new Vector2(followMe.position.x, followMe.position.y);
					followMe = hit.transform;

					//Yes, I know I'm a lazy turd. :)   - Michael
					try
					{
						hitObject.SendMessage("clickAway");
					}
					catch (Exception e)
					{
					}

					/*currentArea.setVisibleAreas(-1);
					currentArea = followMe.parent.parent.GetComponent<Areas>();
					currentArea.setVisibleAreas(1);*/

					if (hit.transform.tag == "actionJump")
					{
						hitObject = hit.transform.gameObject;
						hitObject.SendMessage("clickOn");
						//lastClicked = hit.transform.gameObject.GetComponent<UniversalClick>();
						//lastClicked.clickOn ();
					}
				}

				Cursor.SetCursor(myMouse, new Vector2(160, 160), CursorMode.Auto);
			}
			else
			{
				Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
			}
		}
		else
		{
			Cursor.SetCursor (null, Vector2.zero, CursorMode.ForceSoftware);
		}

		//Debug.Log (flyTime - Time.fixedTime);
		if (flyTime - Time.fixedTime >= 0)
		{
			multiplier = (Mathf.Cos (((flyTime - Time.fixedTime - 1f) / 0.25f) * (Mathf.PI / 2)) + 1) / 2;
			multiplier = Mathf.Sin (multiplier * Mathf.PI / 2);
			transform.position = new Vector3(flyFrom.x + ((followMe.transform.position.x - flyFrom.x) * multiplier), 
			                                 flyFrom.y + ((followMe.transform.position.y - flyFrom.y) * multiplier), -10);
		}
		else
		{
			transform.position = new Vector3(followMe.position.x, followMe.position.y, -10);
		}
	}

	public void resetLevel()
	{
		if (flyTime - Time.fixedTime < 0)
		{
			transform.position = levelBegin;
			followMe = firstObject;
		}
	}

	private void follow(Transform trans)
	{
		this.transform.position = new Vector3(trans.position.x, trans.position.y, -10);
	}

	private void rotateMe(Vector3 rotateTo)
	{
		if (rotateTo.y - transform.position.y > 0)
		{
			transform.eulerAngles = new Vector3(0, 0, -Mathf.Atan((rotateTo.x - transform.position.x)/(rotateTo.y - transform.position.y)) * Mathf.Rad2Deg);
		}
		else
		{
			transform.eulerAngles = new Vector3(0, 0, -Mathf.Atan((rotateTo.x - transform.position.x)/(rotateTo.y - transform.position.y)) * Mathf.Rad2Deg + 180);
		}
	}
}