using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public PortalTypes portalType;
	bool finished;

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer("Player") && !finished);
		{
			if(portalType == PortalTypes.UniverseOne)
			{
				GameManager.instance.finishedone = true;
			}
			else if(portalType == PortalTypes.UniverseTwo)
			{
				GameManager.instance.finishedtwo = true;
			}

			GameManager.instance.UpdateUniverse();
			
			finished = true;
		}
	}
}

public enum PortalTypes
{
	UniverseOne,
	UniverseTwo
}