using UnityEngine;
using System.Collections;

public class GravityLever : MonoBehaviour {

	bool showText;
	bool Pressed = false;
	
	public Transform crate;
	
	public Font roboto;
	
	// Use this for initialization
	void Start () {
		crate.rigidbody2D.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(showText && !Pressed)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				crate.rigidbody2D.gravityScale = 1;
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
		if(col.gameObject.layer == LayerMask.NameToLayer("Player"));
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
