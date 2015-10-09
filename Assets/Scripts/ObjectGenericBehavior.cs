using UnityEngine;
using System.Collections;

public class ObjectGenericBehavior : MonoBehaviour {
	protected ReachPointBehavior r;
	protected PlayerBehavior p;
	// Use this for initialization
	protected void Start () { //protected - accessible from derived classes
		r = GetComponentInChildren<ReachPointBehavior>();
		p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
	}
	
	// Update is called once per frame
	protected void Update () {
	
	}

	protected void OnMouseOver () {
		if(Input.GetMouseButton(1))
		{
			p.SetTargetPoint(r.GetX(), r.GetZ (), this);
			p.AboutToUseObject = true;
		}
	}

	
	public virtual void OnUseObject() //virtual can be overridden by inheritance
	{
		Debug.Log("Clicked generic object");
	}
}
