using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartHomeDevice : MonoBehaviour {
	public float speed;
	public bool collisionCheck = false;
	private string jumpButton = "Jump_P1";
	private string horizontalCtrl = "Horizontal_P1";
	private string trigger = "Fire_P1";
	private string special = "Fire_P2";
	public Vector2 jumpHeight;
	private int JumpLimit = 3;
	private int CurrentJump = 0;
	public bool isGrounded = true;
	public bool facingRight = true;
	int State = 0;
	// Use this for initialization
	void Start () {
		switch (this.tag) {
		case "Player1":
			//healthBar = GameObject.Find ("HealthBar1").GetComponent<SpriteRenderer>();
			//TO DO
			//put controls here
			jumpButton = "Jump_P1";
			horizontalCtrl = "Horizontal_P1";
			trigger = "Fire_P1";
			special = "Fire2_P1";
			break;
		case "Player2":
			//healthBar = GameObject.Find ("HealthBar2").GetComponent<SpriteRenderer>();
			//TO DO
			//put controls here
			jumpButton = "Jump_P2";
			horizontalCtrl = "Horizontal_P2";
			trigger = "Fire_P2";
			special = "Fire2_P2";
			break;

		}

	}
	
	// Update is called once per frame
	void Update () {
		if (WinCondition.End == true) {
			speed = 0;
		}
		float moveHorizontal = Input.GetAxisRaw(horizontalCtrl);
		transform.position += transform.right * Time.deltaTime * speed * moveHorizontal;
		if (moveHorizontal > 0 && !facingRight)
		{
			//Flip();
			//flip particles
		}
		else if (moveHorizontal < 0 && facingRight)
		{ 
			//Flip();
			//flip particles
		}

		if (Input.GetButtonDown(jumpButton) && CurrentJump < JumpLimit)
		{
			//speed = 0;
			//collisionCheck = false;
			GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
			isGrounded = false;
			CurrentJump++;
			//State = 2;
			//anim.SetInteger("State", State);
		}
		if (CurrentJump >= JumpLimit) {
			if (isGrounded == true) {
				CurrentJump = 0;
			}
		}

	}

	//Modify to flip a particle effect
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Floor") {
			isGrounded = true;
			//State = 0;
			//anim.SetInteger ("State", State);
		}
	}
}
