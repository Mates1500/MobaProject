using UnityEngine;
using System.Collections;

public class FlagBehavior : ObjectGenericBehavior {
	bool beingCarried;
	Vector3 startPos;
	public team flagTeam;

	void Start()
	{
		base.Start();
		beingCarried = false;
		startPos = transform.position;
	}

	public override void OnUseObject ()
	{
		if(p.playerTeam != this.flagTeam) //we don't want to pick up our own team's flag, resetting it into our base when the person dies will be implemented later
		{
		Debug.Log("Picked up the flag");
		beingCarried = true;
		p.FlagTeam = this.flagTeam;
		p.IsCarryingFlag = true;
		p.FlagRef = this;
		}
		else
		{
			Debug.Log ("Can't pick up your own flag");
		}
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
