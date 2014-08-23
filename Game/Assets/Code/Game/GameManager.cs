using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public PlayerController UniverseOne;
	public PlayerController UniverseTwo;
	public SmoothCamera2D GameCamera;

	bool finishedone,finishedtwo;

	void Start () {
		DontDestroyOnLoad (this.gameObject);
		UniverseOne.Active = true;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			UniverseOne.Active = true;
			UniverseTwo.Active = false;
			GameCamera.target = UniverseOne.transform;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			UniverseOne.Active = false;
			UniverseTwo.Active = true;
			GameCamera.target = UniverseTwo.transform;
		}
	}
}
