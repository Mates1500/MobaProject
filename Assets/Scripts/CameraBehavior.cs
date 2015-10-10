﻿using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {
	public float movTol; //tolerance for the difference from the edge of the screen
	public float speed; //speed at which the camera moves
	Transform mCam;
	Vector3 mPos;
	// Use this for initialization
	void Start () {
		mCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>(); //currently we only desire to move the camera, transform component is good enough
	}
	
	// Update is called once per frame
	void Update () {

	}

	/*FixedUpdate is called along with physics before the frame is rendered, we don't wanna bind 
	 * the camera speed movement to framerate, that would be Dark Souls level of bad
	 */
	void FixedUpdate() 
	{
		Vector3 newPos = mCam.position;
		mPos = Input.mousePosition;
		if(mPos.x < movTol) newPos.x-= speed; //left
		if(mPos.x > Screen.width - movTol) newPos.x+= speed; //right
		if(mPos.y < movTol) newPos.z -= speed; //down
		if(mPos.y > Screen.height - movTol) newPos.z += speed; //up
		mCam.position = newPos;

	}
}
