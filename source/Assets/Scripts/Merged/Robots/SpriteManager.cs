using UnityEngine;
using System.Collections;

public class SpriteManager : MonoBehaviour {

	public Sprite spriteFront;
	public Sprite spriteBack;
	public Sprite spriteFrontGun;
	public Sprite spriteBackGun;

	int shouldSprite = -1;
	int isSprite = -1;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Mathf.Abs (rigidbody2D.velocity.x) > Mathf.Abs (rigidbody2D.velocity.y))
		{
			shouldSprite = 1;
		}
		else
		{
			if (rigidbody2D.velocity.y > 0)
			{
				shouldSprite = 2;
			}
			else
			{
				shouldSprite = 1;
			}
		}

		//update sprite
		if (isSprite != shouldSprite)
		{
			switch (shouldSprite)
			{
			case 1:
				GetComponent<SpriteRenderer>().sprite = spriteFront;
				break;
			case 2:
				GetComponent<SpriteRenderer>().sprite = spriteBack;
				break;
			case 3:
				GetComponent<SpriteRenderer>().sprite = spriteFrontGun;
				break;
			case 4:
				GetComponent<SpriteRenderer>().sprite = spriteBackGun;
				break;
			}

			isSprite = shouldSprite;
		}

		if (rigidbody2D.velocity.x >= 0)
		{
			transform.localScale = new Vector3(-0.1f, 0.1f, 0);
		}
		else
		{
			transform.localScale = new Vector3(0.1f, 0.1f, 0);
		}
	}
}
