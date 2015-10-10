using UnityEngine;
using System.Collections;
using System;

struct flag{
	public FlagBehavior fBeh;
	public bool isCarryingFlag;
}

public class PlayerBehavior : MonoBehaviour {

	Vector3 targetPoint;
	NavMeshAgent navComponent;
	ObjectGenericBehavior s; //<--------------
	public bool reachedDestination;
	public int flagsCaptured;
	bool aboutToUseObject;
	flag fl;
	// Use this for initialization
	void Start () {
		targetPoint = gameObject.transform.position;
		navComponent = gameObject.GetComponent<NavMeshAgent>();
		reachedDestination = true;
		aboutToUseObject = false;
		fl.isCarryingFlag = false;
		flagsCaptured = 0;
	}

	// Update is called once per frame
	void Update () {
		if(!(Mathf.Approximately(targetPoint.x, transform.position.x) && Mathf.Approximately(targetPoint.z, transform.position.z))) 
		{	//^Y doesn't matter for pick up and makes things more complicated for no good reason anyway
			reachedDestination = false;
			navComponent.SetDestination(targetPoint); //Movement specific stuff can be controlled in the Player NavMeshAgent component
		}
		else
		{
			reachedDestination = true;
			if(aboutToUseObject)
			{
				s.OnUseObject(); //<-----------
				aboutToUseObject = false;
			}

		}
	}

	public void SetTargetPoint(float v1, float v2, float v3)
	{
		Vector3 tempTargetPoint = new Vector3(v1, v2, v3);
		if(tempTargetPoint != targetPoint) targetPoint = new Vector3(v1, v2, v3);
	}

	public void SetTargetPoint(float v1, float v2, float v3, ObjectGenericBehavior accessor)//<------------
	{
		targetPoint = new Vector3(v1, gameObject.transform.position.y, v3);
		s = accessor;
	}

	public bool AboutToUseObject
	{
		get{return aboutToUseObject;}
		set{aboutToUseObject = value;}
	}
	

	public bool IsCarryingFlag
	{
		get{return fl.isCarryingFlag;}
		set{fl.isCarryingFlag = value;}
	}
	
	public int FlagsCaptured
	{
		get{return flagsCaptured;}
		set{flagsCaptured = value;}
	}

	public FlagBehavior FlagRef
	{
		get{return fl.fBeh;}
		set{fl.fBeh = value;}
	}
}
