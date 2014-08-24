using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	private float x;
	public float offset;
	public bool followCamera;

	void Start () 
	{
		x = transform.position.x + 32;
	}

	void FixedUpdate () 
	{
		if(followCamera)
		{
			//Vector3 pos = transform.position;
			//pos.x = ((Camera.main.transform.position.x) - x)/offset;
			//transform.position = pos;

			Vector3 newPos = transform.position;
			newPos.x = (x-(Camera.main.transform.position.x/offset));
			transform.position = newPos;
		}
		else
		{
			Vector3 pos = transform.position;
			pos.x = (x - Camera.main.transform.position.x)/offset;
			transform.position = pos;
		}
	}
}
