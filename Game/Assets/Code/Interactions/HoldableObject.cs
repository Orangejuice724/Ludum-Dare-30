using UnityEngine;
using System.Collections;

public class HoldableObject : MonoBehaviour {

	bool amBeingHeld;
	public PlayerController pCont;
	bool canLetGo;

	void Start () {
		canLetGo = false;
	}

	void Update () {
		if(amBeingHeld)
		{
			rigidbody2D.gravityScale = 0;
		}
		else
		{
			rigidbody2D.gravityScale = 1;
		}

		if(Vector3.Distance(transform.position, pCont.transform.position) < 2)
		{
			if(!pCont.holdingObject && pCont.Active)
			{
				if(Input.GetKeyUp(KeyCode.F))
				{
					rigidbody2D.fixedAngle = true;
					if(gameObject.GetComponent<SyncedCrate>() != null)
					{
						if(gameObject.GetComponent<SyncedCrate>().otherCrate != null)
						{
							gameObject.GetComponent<SyncedCrate>().otherCrate.rigidbody2D.isKinematic = true;
						}
					}
					StartCoroutine(waitForHold());
					amBeingHeld = true;
					pCont.holdingObject = true;
					if(pCont.facingRight)
					{
						Vector3 pos = pCont.transform.position;
						pos.x += 1;
						pos.y += 0.5f;
						transform.position = pos;
					}
					else
					{
						Vector3 pos = pCont.transform.position;
						pos.x -= 1;
						pos.y += 0.5f;
						transform.position = pos;
					}
				}
			}
		}

		if(amBeingHeld && canLetGo)
		{
			//if(pCont.rigidbody2D.velocity.magnitude > 0.0f)
			//{
			if(pCont.facingRight)
			{
				Vector3 pos = pCont.transform.position;
				pos.x += 1;
				pos.y += 0.5f;
				transform.position = pos;
			}
			else
			{
				Vector3 pos = pCont.transform.position;
				pos.x -= 1;
				pos.y += 0.5f;
				transform.position = pos;
			}
			//}

			if(Input.GetKeyUp(KeyCode.F))
			{
				rigidbody2D.fixedAngle = false;
				pCont.holdingObject = false;
				amBeingHeld = false;
				canLetGo = false;

				if(gameObject.GetComponent<SyncedCrate>() != null)
				{
					if(gameObject.GetComponent<SyncedCrate>().otherCrate != null)
					{
						gameObject.GetComponent<SyncedCrate>().otherCrate.rigidbody2D.isKinematic = false;
					}
				}
			}
		}
	}

	IEnumerator waitForHold()
	{
		yield return new WaitForSeconds(0.5f);
		canLetGo = true;
	}
}
