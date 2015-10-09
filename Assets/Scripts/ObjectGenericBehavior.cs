using UnityEngine;
using System.Collections;

public class ObjectGenericBehavior : MonoBehaviour {
	ReachPointBehavior r;
	PlayerBehavior p;
	// Use this for initialization
	void Start () {
		r = GetComponentInChildren<ReachPointBehavior>();
		p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseUp()
	{
		p.SetTargetPoint(r.GetX(), r.GetZ (), this);
		p.AboutToUseObject = true;
	}
	
	public virtual void OnUseObject() //virtual can be overridden by inheritance
	{
		Debug.Log("Clicked generic object");
	}
}
