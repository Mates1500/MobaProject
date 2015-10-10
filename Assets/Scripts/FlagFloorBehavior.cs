using UnityEngine;
using System.Collections;

public class FlagFloorBehavior : ObjectGenericBehavior {
	public team cPointTeam;

	public override void OnUseObject()
	{
		if(p.IsCarryingFlag && p.FlagTeam != this.cPointTeam) //can't capture our own flag
		{
			Debug.Log("Captured the flag");
			p.IsCarryingFlag = false;
			p.FlagsCaptured++;
			p.FlagRef.resetFlag();
		}
	}
}
