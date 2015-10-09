using UnityEngine;
using System.Collections;
using System;

public class PlayerBehavior : MonoBehaviour {
	Vector3 targetPoint;
	NavMeshAgent navComponent;
	ObjectGenericBehavior s; //<--------------
	public bool reachedDestination;
	bool aboutToUseObject;
	bool readyToUseObject;
	// Use this for initialization
	void Start () {
		targetPoint = gameObject.transform.position;
		navComponent = gameObject.GetComponent<NavMeshAgent>();
		reachedDestination = true;
		aboutToUseObject = false;
		readyToUseObject = false;
	}

	// Update is called once per frame
	void Update () {

		if(gameObject.transform.position != targetPoint)
		{
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

	public void SetTargetPoint(float v1, float v3)
	{
		targetPoint = new Vector3(v1, gameObject.transform.position.y, v3);
	}

	public void SetTargetPoint(float v1, float v3, ObjectGenericBehavior accessor)//<------------
	{
		targetPoint = new Vector3(v1, gameObject.transform.position.y, v3);
		s = accessor;
	}

	public bool AboutToUseObject
	{
		get{return aboutToUseObject;}
		set{aboutToUseObject = value;}
	}

	public bool ReadyToUseObject
	{
		get{return readyToUseObject;}
		set{readyToUseObject = value;}
	}
}
