using UnityEngine;
using System.Collections;

public class FlagBehavior : ObjectGenericBehavior {
	bool beingCarried;
	Vector3 startPos;

	void Start()
	{
		base.Start();
		beingCarried = false;
		startPos = transform.position;
	}

	public override void OnUseObject ()
	{
		Debug.Log("Picked up the flag");
		beingCarried = true;
		p.IsCarryingFlag = true;
		p.FlagRef = this;
	}

	protected void Update()
	{
		base.Update();
		if(beingCarried)
		{
			transform.position = p.transform.position; //anchors itself inside the player
		}
	}

	public void resetFlag()
	{
		beingCarried = false;
		transform.position = startPos;
	}
	
}
