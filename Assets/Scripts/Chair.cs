using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chair : MonoBehaviour {
    public float speed;
    public bool collisionCheck = false;
    private string jumpButton = "Jump_P1";
    private string horizontalCtrl = "Horizontal_P1";
    private string trigger = "Fire_P1";

    //Fighting
    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.25f;
    public Collider2D attackTrigger;

    public bool facingRight = true;

    private Animator anim;
    int State = 0;

    public float health = 100f;
    public float damageAmount = 10f;
    public SpriteRenderer healthBar;
    private Vector3 healthScale;

    public Vector2 jumpHeight;

    public bool isGrounded = true;

    void Start () {
		switch (this.tag) {
		case "Player1":
			healthBar = GameObject.Find ("HealthBar1").GetComponent<SpriteRenderer>();
			//TO DO
			//put controls here
            jumpButton = "Jump_P1";
            horizontalCtrl = "Horizontal_P1";
            trigger = "Fire_P1";
			break;
		case "Player2":
			healthBar = GameObject.Find ("HealthBar2").GetComponent<SpriteRenderer>();;
            //TO DO
            //put controls here
            jumpButton = "Jump_P2";
            horizontalCtrl = "Horizontal_P2";
            trigger = "Fire_P2";
            break;

		}
		healthScale = healthBar.transform.localScale;
		attackTrigger.enabled = false;
        anim = GetComponent<Animator>();
    }

    void Awake()
    {
		
    }

    // Update is called once per frame
    void Update() {
		UpdateHealthBar();
		float moveHorizontal = Input.GetAxisRaw(horizontalCtrl);
        //float jump = Input.GetAxis("Jump_P1");
        //float moveVertical = Input.GetAxis("Vertical");
        transform.position += transform.right * Time.deltaTime * speed * moveHorizontal;
        //transform.position += transform.up * Time.deltaTime * speed * moveVertical;

        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveHorizontal < 0 && facingRight)
        { 
            Flip();
        }

        if (Input.GetButtonDown(jumpButton) && isGrounded)
        {
            //speed = 0;
            //collisionCheck = false;
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
            State = 2;
            anim.SetInteger("State", State);
        }
        else if (Mathf.Abs(moveHorizontal) >= 0.0001)
        {
            State = 3;
            anim.SetInteger("State", State);
        }
        else if(Input.anyKey == false)// && anim != null)//|| Mathf.Abs(moveHorizontal) >= 0
        {
            State = 0;
            anim.SetInteger("State", State);
        }
        /*if (Input.GetButtonDown(trigger))
        {
            State = 1;
            anim.SetInteger("State", State);
        }*/
        /* if( anim.GetCurrentAnimatorStateInfo(0).IsName("ChairRun"))
         {
             // do something
             State = 0;
             anim.SetInteger("State", State);
         }*/
        if (Input.GetButtonDown(trigger) && !attacking)
            {
                attacking = true;
                attackTimer = attackCd;
                attackTrigger.enabled = true;
                //State = 1;
                anim.SetTrigger("Attack");
            }

            if (attacking)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    attacking = false;
                    attackTrigger.enabled = false;
                }
            }

            if (health <= 0)
            {
                Death();
            }
        //anim.SetInteger("State", State);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void Attack()
    {

    }
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "attackTrigger")
        {
            TakeDamage();
            //UpdateHealthBar();
        }
        /*else if (col.gameObject.name == "attackTrigger")
        {
            Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }*/
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            isGrounded = true;
            State = 0;
            anim.SetInteger("State", State);
        }
        else
        {
            //TakeDamage();
            //UpdateHealthBar();
        }
    }
}
