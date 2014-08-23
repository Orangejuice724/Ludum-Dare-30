using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer("Player"));
		{
			Debug.Log (col.transform.parent.parent.name);
			if(col.transform.parent.parent.GetComponent<PlayerController>().Active)
				col.transform.parent.parent.GetComponent<PlayerController>().Die();
		}
	}
}
