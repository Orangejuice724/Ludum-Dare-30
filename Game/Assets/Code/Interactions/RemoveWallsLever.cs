using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RemoveWallsLever : MonoBehaviour {

	bool showText;
	bool Pressed = false;

	public List<Transform> wallsToDelete;
	
	public Font roboto;
	
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(showText && !Pressed)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				if(transform.rotation.y == 180)
					transform.localRotation = Quaternion.Euler(180, 180, 0);
				else
					transform.localRotation = Quaternion.Euler(180, 0, 0);
				for(int i = 0; i < wallsToDelete.Count; i++)
				{
					wallsToDelete[i].gameObject.SetActive(false);
				}
				Pressed = true;
			}
		}
	}
	
	void OnGUI()
	{
		if(!Pressed && showText)
			GUI.Label(new Rect(20, 20, 500, 20), "Press E");
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer("Player") && col.transform.parent.parent.GetComponent<PlayerController>().Active);
		{
			showText = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer("Player"));
		{
			showText = false;
		}
	}
}
