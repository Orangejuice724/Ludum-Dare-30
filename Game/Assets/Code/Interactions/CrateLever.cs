using UnityEngine;
using System.Collections;

public class CrateLever : MonoBehaviour {

	bool showText;
	bool Pressed = false;

	public CrateController crate;

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
				crate.unlocked = true;
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
		if(col.gameObject.layer == 8)
		{
			showText = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.layer == 8)
		{
			showText = false;
		}
	}
}
