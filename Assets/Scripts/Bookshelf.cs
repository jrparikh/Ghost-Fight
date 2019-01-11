using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bookshelf : MonoBehaviour {

    public float speed;
    //public Rigidbody2D rb2d;

    public GameObject ProjectileRight, ProjectileLeft;
    public GameObject SpecialProjectileRight, SpecialProjectileLeft, SpecialProjectileRight2, SpecialProjectileLeft2, SpecialProjectileRight3, SpecialProjectileLeft3;
    public float fireSpeed;
    public float fireRate;
    public bool collisionCheck = false;
    public Rigidbody2D rb2d;

    public bool facingRight = true;
    public int direction = 0;

    private float health = 125f;
    public float damageAmount = 10f;
    public SpriteRenderer healthBar;
    private Vector3 healthScale;

    private string jumpButton = "Jump_P2";
    private string horizontalCtrl = "Horizontal_P2";
    private string verticalCtrl = "Vertical_P2";
    private string trigger = "Fire_P2";
    private string special = "Fire2_P2";

    //Fighting
    private bool attacking = false;
    private bool Sattacking = false;
    private float attackTimer = 0;
    private float SattackTimer = 0;
    private float attackCd = 0.25f;
    private float SattackCd = 0.90f;

    public float jumpHeight;
    public bool isGrounded = true;
    private Animator anim;
    int State = 0;

	//audio
	public AudioSource Moving;
	public AudioSource Shooting;
	public AudioSource Shotgun;
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
			//healthBar = GameObject.Find ("HealthBar2").GetComponent<SpriteRenderer>();;
            //TO DO
            //put controls here
            jumpButton = "Jump_P2";
            horizontalCtrl = "Horizontal_P2";
            verticalCtrl = "Vertical_P2";
            trigger = "Fire_P2";
            special = "Fire2_P2";
            break;

		}
		//healthScale = healthBar.transform.localScale;
		GetComponent<Health>().Myhealth = health;
		rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Awake()
    {
    }
    // Update is called once per frame
    void Update () {
		//UpdateHealthBar();
		if (WinCondition.End == true) {
			speed = 0;
		}
		float moveHorizontal = Input.GetAxisRaw(horizontalCtrl);
        float moveVertical = Input.GetAxisRaw(verticalCtrl);
        transform.position += transform.right * Time.deltaTime * speed * moveHorizontal;
        //transform.position += transform.up * Time.deltaTime * speed * moveVertical;
        //Vector2 move = new Vector2(moveHorizontal,0);
        //rb2d.velocity = move * speed;

        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
            direction = 1;
        }else if (moveHorizontal < 0 && facingRight)
        {
            Flip();
            direction = 2;
        }
        if (Input.GetButtonDown(jumpButton) && isGrounded)
        {
            //speed = 0;
            //collisionCheck = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
            isGrounded = false;
        }

        if (Input.GetButtonDown(trigger) && !attacking) //&& collisionCheck == true)
        {
            attacking = true;
            attackTimer = attackCd;
            Fire();
            Shooting.Play ();
			anim.SetTrigger("Attack");
        }
        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
            }
        }
        if (Input.GetButtonDown(special) && !Sattacking)
        {
            SpecialAttack();
            Sattacking = true;
            SattackTimer = SattackCd;
            Shotgun.Play ();
            anim.SetTrigger("Attack");
        }
        if (Sattacking)
        {
            if (SattackTimer > 0)
            {
                SattackTimer -= Time.deltaTime;
            }
            else
            {
                Sattacking = false;
            }
        }

        if (Mathf.Abs(moveHorizontal) >= 0.0001)
        {
            State = 1;
			if (!Moving.isPlaying) {
				Moving.Play ();
			}
            anim.SetInteger("State", State);
        }
        else if (Input.anyKey == false)
        {
            State = 0;
			Moving.Stop ();
            anim.SetInteger("State", State);
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
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            isGrounded = true;
            State = 0;
            anim.SetInteger("State", State);
        }
        else if (col.gameObject.tag == "attackTrigger")
        {
            //TakeDamage();
            //UpdateHealthBar();
        }
    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "attackTrigger")
        {
            TakeDamage();
    //UpdateHealthBar();
        }
    }*/
void Fire()
    {
        if (facingRight)
        {
            GameObject clone = (GameObject)Instantiate(ProjectileRight, new Vector3(transform.position.x, transform.position.y), transform.rotation);
            Destroy(clone, 2.0f);
            Physics2D.IgnoreCollision(clone.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }

        if (!facingRight)
        {
            GameObject clone = (GameObject)Instantiate(ProjectileLeft, new Vector3(transform.position.x, transform.position.y), transform.rotation);
            Destroy(clone, 2.0f);
            Physics2D.IgnoreCollision(clone.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    void SpecialAttack()
    {
        if (facingRight)
        {
            //center bullet
            GameObject clone = (GameObject)Instantiate(SpecialProjectileRight3, new Vector3(transform.position.x, transform.position.y), transform.rotation);
            Destroy(clone, 0.25f);
            Physics2D.IgnoreCollision(clone.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

            //top bullet
            GameObject clone1 = (GameObject)Instantiate(SpecialProjectileRight, new Vector3(transform.position.x, transform.position.y + 0.5f), Quaternion.Euler(0, 30, 0));
            Destroy(clone1, 0.25f);
            Physics2D.IgnoreCollision(clone1.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

            //bottom bullet
            GameObject clone2 = (GameObject)Instantiate(SpecialProjectileRight2, new Vector3(transform.position.x, transform.position.y - 0.5f), transform.rotation);
            Destroy(clone2, 0.25f);
            Physics2D.IgnoreCollision(clone2.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }

        if (!facingRight)
        {
            //center bullet
            GameObject clone = (GameObject)Instantiate(SpecialProjectileLeft3, new Vector3(transform.position.x, transform.position.y), transform.rotation);
            Destroy(clone, 0.25f);
            Physics2D.IgnoreCollision(clone.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

            //top bullet
            GameObject clone1 = (GameObject)Instantiate(SpecialProjectileLeft, new Vector3(transform.position.x, transform.position.y + 0.50f), transform.rotation);
            Destroy(clone1, 0.25f);
            Physics2D.IgnoreCollision(clone1.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

            //bottom bullet
            GameObject clone2 = (GameObject)Instantiate(SpecialProjectileLeft2, new Vector3(transform.position.x, transform.position.y - 0.50f), transform.rotation);
            Destroy(clone2, 0.25f);
            Physics2D.IgnoreCollision(clone2.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
	/*
    void TakeDamage()
    {
        health -= damageAmount;
    }

    public void UpdateHealthBar()
    {
        // Set the health bar's colour to proportion of the way between green and red based on the player's health.
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);

        // Set the scale of the health bar to be proportional to the player's health.
        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
    }
	
    void Death()
    {       
        //Destroy(gameObject);
        SceneManager.LoadScene("Test");
    }
*/
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
