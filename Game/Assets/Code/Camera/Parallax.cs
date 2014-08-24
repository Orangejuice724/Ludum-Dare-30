using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	private float x;
	public int offset;
	public bool followCamera;

	void Start () 
	{
		x = Camera.main.transform.position.x;
	}

	void Update () 
	{
		if(followCamera)
		{
			Vector3 pos = transform.position;
			pos.x = (Camera.main.transform.position.x - x)/offset;
			transform.position = pos;
		}
		else
		{

		}
	}
}
