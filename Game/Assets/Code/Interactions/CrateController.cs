using UnityEngine;
using System.Collections;

public class CrateController : MonoBehaviour {

	public bool unlocked = false;

	void Awake() 
	{
		if(unlocked == false)
		{
			rigidbody2D.gravityScale = 0;
		}
	}

	void Update () 
	{
		if(unlocked == true)
		{
			rigidbody2D.gravityScale = 1;
		}
	}
}
