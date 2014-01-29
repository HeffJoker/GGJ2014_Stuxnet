using UnityEngine;
using System.Collections;

public class RobotControl : UniversalClick {

	Vector2 mouseLocation;

	Vector2 targetLocation;
	public bool isMoving;
	public float speed;

	public bool isPlayerPossessed = false;
	private SeePlayer finder;
	private float myAngle;

	// Use this for initialization
	void Start () 
	{
		finder = gameObject.GetComponent<SeePlayer>();

		if(finder != null)
			finder.isAlternateAngle = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isPlayerPossessed)
		{
			Camera.main.SendMessage("follow", transform);

			/*mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//Debug.Log (mouseLocation);

			if (!isMoving)
			{
				//rotateMe ();
			}
			else
			{
				if (rigidbody2D.velocity == Vector2.zero)
				{
					isMoving = false;
				}

				if (Vector2.Distance (targetLocation, new Vector2(transform.position.x, transform.position.y)) < .1f)
				{
					isMoving = false;
					rigidbody2D.velocity = new Vector2(0, 0);
				}
			}
	
			if (Input.GetMouseButtonDown(0))
			{
				rotateMe ();
				isMoving = true;
				targetLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				rigidbody2D.velocity = new Vector2(mouseLocation.x - transform.position.x, mouseLocation.y - transform.position.y).normalized * speed;
			}
			*/
		}

		//calculate angle for SeePlayer script
		if (rigidbody2D.velocity.x != 0)
		{
			myAngle = Mathf.Atan (rigidbody2D.velocity.y / rigidbody2D.velocity.x);
			myAngle = myAngle * Mathf.Rad2Deg;
		}
		if (rigidbody2D.velocity.x < 0)
		{
			myAngle = myAngle + 180;
		}
		if (myAngle < 0)
		{
			myAngle += 360;
		}

		if(finder != null)
		{
			finder.alternateAngle = myAngle;

			if (finder.isSee)
			{
				GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
				mainCamera.GetComponent<CameraJump>().resetLevel();
			}
		}
	}

	public override void clickOn()
	{
		isPlayerPossessed = true;
	}

	public override void clickAway()
	{
		isPlayerPossessed = false;
		//gameObject.GetComponent<PathFollower>().MoveToNextNode();
	}

	private void rotateMe()
	{
		if (mouseLocation.y - transform.position.y > 0)
		{
			transform.eulerAngles = new Vector3(0, 0, -Mathf.Atan((mouseLocation.x - transform.position.x)/(mouseLocation.y - transform.position.y)) * Mathf.Rad2Deg);
		}
		else
		{
			transform.eulerAngles = new Vector3(0, 0, -Mathf.Atan((mouseLocation.x - transform.position.x)/(mouseLocation.y - transform.position.y)) * Mathf.Rad2Deg + 180);
		}
	}
}
