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

	void Awake()
	{
		finishedone = false;
		finishedtwo = false;
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
	}

	public void Reset()
	{
		finishedone = false;
		finishedtwo = false;
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
	}

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

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
		{
			if(level == 1)
				RestartLevelOne();
			else
				Application.LoadLevel(Application.loadedLevel);
		}

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

		//temporary
		if(Input.GetKeyDown(KeyCode.Keypad7))
		   Application.LoadLevel(7);
	}

	//This will be used only if the reset button is pressed when you're on level one, it's a work around as a few components have DontDestroyOnLoad()
	void RestartLevelOne()
	{
		Vector3 uOne = new Vector3(1, -2, 0);
		Vector3 uTwo = new Vector3(111, -2, 0);

		UniverseOne.transform.position = uOne;
		UniverseTwo.transform.position = uTwo;

		finishedone = false;
		finishedtwo = false;
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
