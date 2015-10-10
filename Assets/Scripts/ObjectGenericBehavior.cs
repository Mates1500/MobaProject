using UnityEngine;
using System.Collections;

public class ObjectGenericBehavior : MonoBehaviour {
	protected ReachPointBehavior r;
	protected PlayerBehavior p;
	public bool hasReachPoint; //important, required for objects that use physics collision, if set to false, it's activated upon reaching the object on X and Z axes
	Rect areaRect;
	Vector2 playerCoords;
	// Use this for initialization
	protected void Start () { //protected - accessible from derived classes
		r = GetComponentInChildren<ReachPointBehavior>();
		p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
		if(!hasReachPoint)
		{
			areaRect = new Rect(transform.position.x - transform.localScale.x * 0.5f, transform.position.z - transform.localScale.z * 0.5f, transform.localScale.x, transform.localScale.z);
			playerCoords = new Vector2(p.transform.position.x, p.transform.position.z);
		}
	}
	
	// Update is called once per frame
	protected void Update () {
		if(!hasReachPoint)
		{
			playerCoords.x = p.transform.position.x;
			playerCoords.y = p.transform.position.z;
			if(areaRect.Contains(playerCoords)) OnUseObject();
		}
	}

	protected void OnMouseOver () {
		//Debug.Log ("Mouse Enter");
		if(hasReachPoint)
		{
			if(Input.GetMouseButton(1))
			{
				//Debug.Log ("Flag Clicked");
				p.SetTargetPoint(r.GetX(), p.transform.position.y, r.GetZ (), this);
				p.AboutToUseObject = true;
			}
		}
	}


	
	public virtual void OnUseObject() //virtual can be overridden by inheritance
	{
		Debug.Log("Clicked generic object");
	}
}
