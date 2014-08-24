using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public GUISkin menuSkin;
	public SmoothCamera2D smoothCamera;

	void Start () {
		smoothCamera.enabled = false;
	}

	void Update () {
	
	}

	void OnGUI()
	{
		GUI.skin = menuSkin;
	}

	public void MoveScreen()
	{
		smoothCamera.enabled = true;
	}
}
