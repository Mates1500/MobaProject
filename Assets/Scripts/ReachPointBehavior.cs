using UnityEngine;
using System.Collections;

public class ReachPointBehavior : MonoBehaviour {
	float X;
	float Z;
	// Use this for initialization
	void Start () {
		X = transform.position.x;
		Z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float GetX()
	{
		return X;
	}

	public float GetZ()
	{
		return Z;
	}
}
