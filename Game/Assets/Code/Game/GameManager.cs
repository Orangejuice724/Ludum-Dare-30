using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public PlayerController UniverseOne;
	public PlayerController UniverseTwo;
	public SmoothCamera2D GameCamera;

	int level = 1;

	public static GameManager instance;

	//[HideInInspector]
	public bool finishedone,finishedtwo;

	void Start () {
		DontDestroyOnLoad (this.gameObject);
		UniverseOne.Active = true;
		instance = this;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1) && !finishedone) {
			UniverseOne.Active = true;
			UniverseTwo.Active = false;
			GameCamera.target = UniverseOne.transform;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2) && !finishedtwo) {
			UniverseOne.Active = false;
			UniverseTwo.Active = true;
			GameCamera.target = UniverseTwo.transform;
		}

		if(Input.GetKeyDown (KeyCode.R))
			Application.LoadLevel(Application.loadedLevel);

		if(UniverseOne == null)
		{
			UniverseOne = GameObject.FindGameObjectWithTag("UniverseOne").GetComponent<PlayerController>();
		}
		if(UniverseTwo == null)
		{
			UniverseTwo = GameObject.FindGameObjectWithTag("UniverseTwo").GetComponent<PlayerController>();
		}

		if(GameCamera.target == null)
		{
			GameCamera.target = UniverseOne.transform;
		}

		if(!UniverseOne.Active && !UniverseTwo.Active)
			UniverseOne.Active = true;
	}

	public void UpdateUniverse()
	{
		if(finishedone && finishedtwo)
		{
			finishedone = false;
			finishedtwo = false;
			level++;
			if(UniverseOne == null)
			{
				UniverseOne = GameObject.FindGameObjectWithTag("UniverseOne").GetComponent<PlayerController>();
			}
			if(UniverseTwo == null)
			{
				UniverseTwo = GameObject.FindGameObjectWithTag("UniverseTwo").GetComponent<PlayerController>();
			}
			
			UniverseOne.Active = true;
			UniverseTwo.Active = false;
			GameCamera.target = UniverseOne.transform;
			Application.LoadLevel(level);
		}
		else if(finishedone && !finishedtwo)
		{
			UniverseOne.Active = false;
			UniverseTwo.Active = true;
			GameCamera.target = UniverseTwo.transform;
		}
		else if(finishedtwo && !finishedone)
		{
			UniverseOne.Active = true;
			UniverseTwo.Active = false;
			GameCamera.target = UniverseOne.transform;
		}

	}
}
