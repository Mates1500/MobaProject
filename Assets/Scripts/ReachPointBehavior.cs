using UnityEngine;
using System.Collections;

public class ReachPointBehavior : MonoBehaviour {
	float X;
	float Y;
	float Z;
	// Use this for initialization
	void Start () {
		X = transform.position.x;
		Y = transform.position.y; 
		Z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float GetX()
	{
		return X;
	}

	public float GetY()
	{
		return Y;
	}

	public float GetZ()
	{
		return Z;
	}
}
