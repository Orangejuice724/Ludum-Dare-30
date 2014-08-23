using UnityEngine;
using System.Collections;

public class BreakTile : MonoBehaviour {

	public Transform tile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer("Player"));
		{
			tile.gameObject.SetActive(false);
		}
	}
}
