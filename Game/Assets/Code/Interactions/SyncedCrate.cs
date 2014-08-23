using UnityEngine;
using System.Collections;

public class SyncedCrate : MonoBehaviour {

	public OtherCrateLocation ocl = OtherCrateLocation.Left;
	public float distance;
	public Transform otherCrate;

	void Start () {
	
	}

	void Update () {
		Vector3 cratePos = transform.position;
		if(ocl == OtherCrateLocation.Left)
		{
			cratePos.x -= distance;
		}
		else if(ocl == OtherCrateLocation.Right)
		{
			cratePos.x += distance;
		}
		otherCrate.position = cratePos;
		otherCrate.rotation = transform.rotation;
	}
}

public enum OtherCrateLocation
{
	Left,
	Right
}