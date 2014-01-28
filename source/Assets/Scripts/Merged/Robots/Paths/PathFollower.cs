using UnityEngine;
using System.Collections.Generic;

public class PathFollower : MonoBehaviour {
	
	public bool isFollowing;
	public float Speed = 20f;
	public GameObject Path;
	public float DisableTimeout = 2f;

	private List<PathNode> nodes = new List<PathNode>();
	private int currNode = 0;
	private bool reverse = false;
	private Vector2 moveDir = Vector2.zero;
	
	void Start () {

		GameObject node;
		for(int i = 0; i < Path.transform.childCount; ++i)
		{
			node = Path.transform.GetChild(i).gameObject;
			nodes.Add(node.GetComponent<PathNode>());
		}

		nodes.Sort((node1, node2) => { return node1.Index.CompareTo(node2.Index); });

		MoveToNextNode();
	}
	
	void Update()
	{
		//checks if player is in possession of bot
		if (GetComponent<RobotControl>().isPlayerPossessed)
		{
			Camera.main.SendMessage("follow", transform);
			/*if (isFollowing)
			{
				gameObject.SendMessage("Stop");
				isFollowing = false;
			}*/
		}
		else
		{
			if (!isFollowing)
			{
				gameObject.SendMessage("MoveTo", nodes[currNode].transform);
			}
		}
	}

	public void MoveToNextNode()
	{
		isFollowing = true;

		++currNode;

		if(currNode >= nodes.Count)
			currNode = 0;

		PathNode nextNode = nodes[currNode];
		Stop();
		MoveTo(nextNode.transform);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "node")
		{
			if(Vector3.Distance(collider.transform.position, nodes[currNode].transform.position) <= 1f)
				MoveToNextNode();
		}
	}

	// ***************************************************************
	// ********************** MOVEABLE.CS ****************************
	// ***************************************************************

	void RotateTo(Vector3 position)
	{
		if (position.y - transform.position.y > 0)
		{
			transform.eulerAngles = new Vector3(0, 0, -Mathf.Atan((position.x - transform.position.x)/(position.y - transform.position.y)) * Mathf.Rad2Deg);
		}
		else
		{
			transform.eulerAngles = new Vector3(0, 0, -Mathf.Atan((position.x - transform.position.x)/(position.y - transform.position.y)) * Mathf.Rad2Deg + 180);
		}
	}
	
	void Stop()
	{
		rigidbody2D.velocity = Vector2.zero;
		isFollowing = false;
	}
	
	void MoveTo(Transform trans)
	{
		isFollowing = true;
		moveDir = trans.position - transform.position;
		rigidbody2D.AddForce(moveDir.normalized * Speed);
	}
}
