using UnityEngine;
using System.Collections;

public class SeePlayer : MonoBehaviour {

	public float myAngle;
	public float angleToPlayer;
	public float numHits;

	public float maxAngle = 90;
	public bool isSee;
	public float alternateAngle = 0;
	public bool isAlternateAngle = false;

	public Sprite camera90;
	public Sprite camera45;

	private LayerMask glass;
	private GameObject half1;
	private GameObject half2;

	public float multiplySeeSize = 1;
	public float plusAngle = 0;

	// Use this for initialization
	void Start () 
	{
		glass = ~(1 << LayerMask.NameToLayer("Glass"));

		half1 = new GameObject("half1");
		half2 = new GameObject("half2");

		if (maxAngle >= 45)
		{

			half1.transform.position = transform.position;
			half1.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 180 + maxAngle + plusAngle);
			half1.transform.parent = this.transform;
			half1.AddComponent<SpriteRenderer>();
			half1.GetComponent<SpriteRenderer>().sprite = camera90;

			half2.transform.position = transform.position;
			half2.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 90 - maxAngle + plusAngle);
			half2.transform.parent = this.transform;
			half2.AddComponent<SpriteRenderer>();
			half2.GetComponent<SpriteRenderer>().sprite = camera90;
		}
		else
		{
			half1.transform.position = transform.position;
			half1.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 180 + maxAngle + plusAngle);
			half1.transform.parent = this.transform;
			half1.AddComponent<SpriteRenderer>();
			half1.GetComponent<SpriteRenderer>().sprite = camera45;

			half2.transform.position = transform.position;
			half2.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 90 - maxAngle + plusAngle);
			half2.transform.parent = this.transform;
			half2.AddComponent<SpriteRenderer>();
			half2.GetComponent<SpriteRenderer>().sprite = camera45;
		}

		half1.transform.localScale = new Vector3(.3f * multiplySeeSize / transform.localScale.x, .3f * multiplySeeSize/ transform.localScale.y, 0);
		half2.transform.localScale = new Vector3(.3f * multiplySeeSize / transform.localScale.x, .3f * multiplySeeSize/ transform.localScale.y, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isAlternateAngle)
		{
			myAngle = alternateAngle + plusAngle;
			updateShowSeeAngles(myAngle);
		}
		else
		{
			myAngle = transform.eulerAngles.z + plusAngle;
		}

		RaycastHit2D[] hits = Physics2D.LinecastAll(new Vector2(transform.position.x, transform.position.y), new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y), glass);

		numHits = hits.Length;

		if (hits.Length == 2)
		{
			angleToPlayer = getAngle (new Vector2(transform.position.x, transform.position.y), new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y));

			angleToPlayer = myAngle - angleToPlayer - 180;
			if (angleToPlayer <= -180)
			{
				angleToPlayer += 360;
			}

			if (angleToPlayer >= -maxAngle && angleToPlayer <= maxAngle)
			{
				isSee = true;
			}
			else
			{
				isSee = false;
			}
		}
		else
		{
			isSee = false;
		}
	}

	public static float getAngle(Vector2 pointA, Vector2 pointB)
	{
		float distX = pointA.x - pointB.x;
		float distY = pointA.y - pointB.y;
		float myAngle = 0;

		if (distX != 0)
		{
			myAngle = Mathf.Atan (distY / distX);
			myAngle = myAngle * Mathf.Rad2Deg;
		}
		if (distX < 0)
		{
			myAngle = myAngle + 180;
		}
		if (myAngle < 0)
		{
			myAngle += 360;
		}

		return myAngle;
	}

	private void updateShowSeeAngles(float newAngle)
	{
		if (transform.localScale.x >= 0)
		{
			//if (maxAngle >= 45)
			{
				half1.transform.eulerAngles = new Vector3(0, 0, newAngle - 180 + maxAngle);
				half2.transform.eulerAngles = new Vector3(0, 0, newAngle - 90 - maxAngle);
			}
			/*else
			{
				half1.transform.eulerAngles = new Vector3(0, 0, newAngle + 135 + (maxAngle / 2));
				half2.transform.eulerAngles = new Vector3(0, 0, newAngle + 135 - (maxAngle / 2));
			}*/
		}
		else
		{
			//if (maxAngle >= 45)
			{
				half1.transform.eulerAngles = new Vector3(0, 0, newAngle + 135 + (maxAngle / 2));
				half2.transform.eulerAngles = new Vector3(0, 0, newAngle + 135 - (maxAngle / 2));
			}
			/*else
			{
				half1.transform.eulerAngles = new Vector3(0, 0, newAngle + 135 + (maxAngle / 2));
				half2.transform.eulerAngles = new Vector3(0, 0, newAngle + 135 - (maxAngle / 2));
			}*/
		}

		half1.transform.localScale = new Vector3(Mathf.Abs (half1.transform.localScale.x) * (Mathf.Abs (transform.localScale.x) / 
		                                         transform.localScale.x) * multiplySeeSize, half1.transform.localScale.y * multiplySeeSize, 0);
		half2.transform.localScale = new Vector3(Mathf.Abs (half2.transform.localScale.x) * (Mathf.Abs (transform.localScale.x) / 
		                                         transform.localScale.x) * multiplySeeSize, half1.transform.localScale.y * multiplySeeSize, 0);

		//half1.transform.eulerAngles = new Vector3(0, 0, newAngle - 135 - transform.eulerAngles.z);
		//half2.transform.eulerAngles = new Vector3(0, 0, newAngle - 135 - transform.eulerAngles.z);
	}
}
