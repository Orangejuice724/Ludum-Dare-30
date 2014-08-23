using UnityEngine;
using System.Collections;

public class ResetGameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManager.instance.Reset();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
