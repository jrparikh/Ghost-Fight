using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartHomeDevice : MonoBehaviour {
	//Movement
	public float speed;
	public bool collisionCheck = false;
	private string jumpButton = "Jump_P1";
	private string horizontalCtrl = "Horizontal_P1";
    private string verticalCtrl = "Vertical_P1";
    private string trigger = "Fire_P1";
	private string special = "Fire_P2";
	public float jumpHeight;
	private int JumpLimit = 3;
	private int CurrentJump = 0;
	public bool isGrounded = true;
	public bool facingRight = true;
	public bool SheildUP = false;
	public float currSpeed;
	//Attacking
	private bool attacking = false;
	private bool Sattacking = false;
	private float attackTimer = 0;
	private float SattackTimer = 0;
	private float attackCd = 1f;
	private float SattackCd = 5f;
	public  float CurrentHealth;
	public float Sky;
	public GameObject Box;
	//NoteWave Object
	public GameObject NoteWave;

	//Animation
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
            verticalCtrl = "Vertical_P1";
            trigger = "Fire_P1";
			special = "Fire2_P1";
			break;
		case "Player2":
			//healthBar = GameObject.Find ("HealthBar2").GetComponent<SpriteRenderer>();
			//TO DO
			//put controls here
			jumpButton = "Jump_P2";
			horizontalCtrl = "Horizontal_P2";
            verticalCtrl = "Vertical_P2";
            trigger = "Fire_P2";
			special = "Fire2_P2";
			break;

		}
		NoteWave.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (WinCondition.End == true) {
			speed = 0;
		}


		float moveHorizontal = Input.GetAxisRaw (horizontalCtrl);
		float moveVertical = Input.GetAxisRaw (verticalCtrl);
		if(SheildUP == false)
		{
		transform.position += transform.right * Time.deltaTime * speed * moveHorizontal;
	

		if (Input.GetButtonDown (jumpButton) && CurrentJump < JumpLimit) {
			//speed = 0;
			//collisionCheck = false;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
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
		if (Input.GetButtonDown (trigger) && !attacking) { //&& collisionCheck == true)
			attacking = true;
			attackTimer = attackCd;
			Fire ();
			//Shooting.Play ();
			//anim.SetTrigger("Attack");
		}
		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
			}
		}
		}
		//**********************************************
		if (Input.GetButtonDown(special) && !Sattacking)
		{
			SpecialAttack();
			Sattacking = true;
			SattackTimer = SattackCd;
			//bool for SheildUP
			SheildUP = true;
			//pause speed
			CurrentHealth = this.GetComponent<Health> ().Myhealth;
			this.GetComponent<BoxCollider2D> ().enabled = false;
			this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePosition;
		}
		if (Sattacking) {
			if (SattackTimer > 0) {
				SattackTimer -= Time.deltaTime;
			} else {
				Sattacking = false;
				SheildUP = false;
				NoteWave.SetActive(false);
				this.GetComponent<BoxCollider2D> ().enabled = true;
				this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			}
		}
		if (SheildUP == true) {
			if (this.GetComponent<Health> ().Myhealth != CurrentHealth) {
				this.GetComponent<Health> ().Myhealth = CurrentHealth;
				this.GetComponent<Health> ().Damaged = false;
			}

		}

        //check if we are ground and not on layer 10(Player layer)
        if (isGrounded == true && gameObject.layer != 10)
        {
            gameObject.layer = 10; //we set layer to 10
        }

        //check if we are ground and DownArrow key is press
        if (isGrounded == true && moveVertical < 0)

        {
            gameObject.layer = 9; //we set layer to 9(OneWayPlatform)
        }


        //anim.SetInteger("State", State);
}

    //**********************************************

	void Fire()
	{
			//Fade in Drone as well
			GameObject clone = (GameObject)Instantiate(Box, new Vector3(transform.position.x, Sky), transform.rotation);
			clone.GetComponent<ProjectileDamage> ().ParentString = this.tag;
			Destroy(clone, 1.0f);
			//Destroy Drone
	}
	//Modify to flip a particle effect
	void SpecialAttack(){
		NoteWave.SetActive(true);

	}
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
