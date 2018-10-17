using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bookshelf : MonoBehaviour {

    public float speed;
    //public Rigidbody2D rb2d;

    public GameObject ProjectileRight, ProjectileLeft;
    public GameObject SpecialProjectileRight, SpecialProjectileLeft, SpecialProjectileRight2, SpecialProjectileLeft2;
    public float fireSpeed;
    public float fireRate;
    public bool collisionCheck = false;
    public Rigidbody2D rb2d;

    public bool facingRight = true;
    public int direction = 0;

    private float health = 150f;
    public float damageAmount = 10f;
    public SpriteRenderer healthBar;
    private Vector3 healthScale;

    private string jumpButton = "Jump_P2";
    private string horizontalCtrl = "Horizontal_P2";
    private string trigger = "Fire_P2";
    private string special = "Fire2_P2";

    public Vector2 jumpHeight;
    public bool isGrounded = true;
    private Animator anim;
    int State = 0;

	//audio
	public AudioSource Moving;
	public AudioSource Shooting;
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
			//healthBar = GameObject.Find ("HealthBar2").GetComponent<SpriteRenderer>();;
            //TO DO
            //put controls here
            jumpButton = "Jump_P2";
            horizontalCtrl = "Horizontal_P2";
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

		float moveHorizontal = Input.GetAxisRaw(horizontalCtrl);
        //float moveVertical = Input.GetAxis("Vertical");
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
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Input.GetButtonDown(trigger)) //&& collisionCheck == true)
        {
            Fire();
			Shooting.Play ();
			anim.SetTrigger("Attack");
        }

        if (Input.GetButtonDown(special))
        {
            SpecialAttack();
            anim.SetTrigger("Attack");
        }

        if (Mathf.Abs(moveHorizontal) >= 0.0001)
        {
            State = 1;
            anim.SetInteger("State", State);
        }
        else if (Input.anyKey == false)
        {
            State = 0;
            anim.SetInteger("State", State);
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
        fireRate = Time.time + fireSpeed;
        
        if(facingRight)
        {
            GameObject clone = (GameObject)Instantiate(ProjectileRight, new Vector3(transform.position.x + 1.2f, transform.position.y), transform.rotation);
            Destroy(clone, 2.0f);
        }

        if (!facingRight)
        {
            GameObject clone = (GameObject)Instantiate(ProjectileLeft, new Vector3(transform.position.x - 1.2f, transform.position.y), transform.rotation);
            Destroy(clone, 2.0f);
        }
    }

    void SpecialAttack()
    {
        fireRate = Time.time + fireSpeed;

        if (facingRight)
        {
            GameObject clone = (GameObject)Instantiate(ProjectileRight, new Vector3(transform.position.x + 1.2f, transform.position.y), transform.rotation);
            Destroy(clone, 2.0f);
            GameObject clone1 = (GameObject)Instantiate(SpecialProjectileRight, new Vector3(transform.position.x + 1.2f, transform.position.y + 0.5f), Quaternion.Euler(0, 30, 0));
            Destroy(clone1, 2.0f);
            GameObject clone2 = (GameObject)Instantiate(SpecialProjectileRight2, new Vector3(transform.position.x + 1.2f, transform.position.y - 0.5f), transform.rotation);
            Destroy(clone2, 2.0f);
        }

        if (!facingRight)
        {
            GameObject clone = (GameObject)Instantiate(ProjectileLeft, new Vector3(transform.position.x - 1.2f, transform.position.y), transform.rotation);
            Destroy(clone, 2.0f);
            GameObject clone1 = (GameObject)Instantiate(SpecialProjectileLeft, new Vector3(transform.position.x - 1.2f, transform.position.y + 0.50f), transform.rotation);
            Destroy(clone1, 2.0f);
            GameObject clone2 = (GameObject)Instantiate(SpecialProjectileLeft2, new Vector3(transform.position.x - 1.2f, transform.position.y - 0.50f), transform.rotation);
            Destroy(clone2, 2.0f);
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
