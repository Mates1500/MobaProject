using UnityEngine;
using System.Collections;

public class FloorBehavior : MonoBehaviour {
	PlayerBehavior p;
	Camera mCam;
	bool rayHits; //RayCast reflection condition for the 3D environment, we need this to translate mouse position to 3D world position when using perspective camera
	// Use this for initialization
	void Start () {
		p = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
		mCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		rayHits = false;
	}
	
	// Update is called once per frame
	void Update () {
		Ray r = mCam.ScreenPointToRay(Input.mousePosition);
		RaycastHit rHit;
		if (Physics.Raycast(r, out rHit, 30)) {
			rayHits = true;
		}
		//Debug.DrawRay(r.origin, r.direction * 100, Color.yellow);
		if(Input.GetMouseButtonDown(1) && rayHits)//0 - left click, 1 - right click, 2 - mouse wheel click
		{
			Vector3 pos = Input.mousePosition;
			pos.z = rHit.distance; //distance of the raycast reflection by the first object we mouse over
			pos = mCam.ScreenToWorldPoint(pos); //Translation of mouseposition to a relative position in the world under the cursor
			p.SetTargetPoint(pos.x, pos.z); //Using no Y for now, I'll expand the functionality later
			p.AboutToUseObject = false;
			p.ReadyToUseObject = false;
			//Debug.Log("MouseDown Fired Up, Coords - X: " + pos.x + " Z:" + pos.z);
			rayHits = false;
		}



	}

	void OnMouseDown()
	{

	}
}
