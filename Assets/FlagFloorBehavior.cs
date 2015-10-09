using UnityEngine;
using System.Collections;

public class FlagFloorBehavior : ObjectGenericBehavior {

	public override void OnUseObject()
	{
		if(p.IsCarryingFlag)
		{
			Debug.Log("Captured the flag");
			p.FlagsCaptured++;
			p.FlagRef.resetFlag();
		}
	}
}
