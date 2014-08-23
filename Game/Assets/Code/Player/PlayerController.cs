using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	[HideInInspector]
	public bool facingRight = false;

	public bool Active = false;

	public SpriteRenderer drawMe;

	[HideInInspector]
	public bool holdingObject;
	public Sprite Normal, Holding;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask groundLayer;

	void Start () 
	{

	}

	void FixedUpdate () 
	{
		if (!Active)
			return;
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundLayer);

		//if (!grounded)
		//	return;

		float move = Input.GetAxis ("Horizontal");

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

	}

	void Update()
	{
		if (!Active)
			return;
		if ((grounded)&& (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown (KeyCode.Space))) {
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}

		if (transform.position.y <= -64)
			Application.LoadLevel (Application.loadedLevel);

		if(holdingObject)
			drawMe.sprite = Holding;
		else
			drawMe.sprite = Normal;

		//if(Input.GetKeyDown(KeyCode.F))
			//holdingObject = !holdingObject;
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void Die()
	{
		Active = false;
		rigidbody2D.AddForce(new Vector2(0, 6000));
		StartCoroutine(WaitForDeath());
	}

	IEnumerator WaitForDeath()
	{
		yield return new WaitForSeconds(3);
		GameManager.instance.Restart();
	}
}
