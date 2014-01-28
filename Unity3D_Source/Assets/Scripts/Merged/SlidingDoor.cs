using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour {

	public enum SlidingDirection
	{
		LeftToRight,
		RightToLeft,
		TopToBottom,
		BottomToTop
	}

	public float SlidingTime = 0.75f;
	public float SlideAmount = 2f;
	public SlidingDirection SlideDirection = SlidingDirection.LeftToRight;

	private float currSlideTime = 0f;
	private Vector3 startPos;
	private Vector3 endPos;
	private bool isSliding = false;
	private bool opening = true;

	// Use this for initialization
	void Start () 
	{
		SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();

		switch(SlideDirection)
		{
		case SlidingDirection.LeftToRight:
			startPos = transform.position;
			endPos = transform.position + new Vector3(SlideAmount, 0,0); //sprite.sprite.bounds.extents.x * 2f, 0, 0);
			break;
		case SlidingDirection.RightToLeft:
			startPos = transform.position + new Vector3(SlideAmount, 0, 0); //sprite.sprite.bounds.extents.x * 2f, 0, 0);
			endPos = transform.position;
			break;
		case SlidingDirection.TopToBottom:
			startPos = transform.position;
			endPos = transform.position + new Vector3(0, SlideAmount, 0); //sprite.sprite.bounds.extents.y * 2f, 0);
			break;
		case SlidingDirection.BottomToTop:
			startPos = transform.position + new Vector3(0, SlideAmount, 0); // sprite.sprite.bounds.extents.y * 2f, 0);
			endPos = transform.position;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isSliding)
		{
			float rate = 1f / SlidingTime;
			currSlideTime += Time.deltaTime * rate;
			Vector3 toPos, fromPos;

			if(opening)
			{
				toPos = endPos;
				fromPos = startPos;
			}
			else
			{
				toPos = startPos;
				fromPos = endPos;
			}

			transform.position = Vector3.Lerp(fromPos, toPos, currSlideTime);
		
			isSliding = (transform.position != toPos);
		}
	}

	void Slide()
	{
		if(!isSliding)
		{
			isSliding = true;
			opening = !opening;
			currSlideTime = 0f;
		}
	}
}
