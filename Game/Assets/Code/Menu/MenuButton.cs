using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public ButtonTypes buttonType = ButtonTypes.Play;
	public Color hoverColor;
	public Color defaultColor;

	void Start () {
	
	}

	void Update () {
	
	}

	void OnMouseEnter()
	{
		renderer.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		renderer.material.color = defaultColor;
	}

	void OnMouseDown()
	{
		if(buttonType == ButtonTypes.Play)
		{
			Application.LoadLevel(1);
		}
		else if(buttonType == ButtonTypes.Exit)
		{
			Application.Quit();
		}
	}
}

public enum ButtonTypes
{
	Play,
	Exit
}