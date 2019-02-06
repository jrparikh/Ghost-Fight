using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour {

    public float speed;
    private string jumpButton = "Jump_P2";
    private string horizontalCtrl = "Horizontal_P2";
    private string trigger = "Fire_P2";
    private string special = "Fire2_P2";

    public bool facingRight = true;
    public int direction = 0;

    public Vector2 jumpHeight;
    public bool isGrounded = true;
    /*
    private float health = 125f;
    public float damageAmount = 10f;
    public SpriteRenderer healthBar;
    private Vector3 healthScale;
    */

    //Fighting
    private bool attacking = false;
    private bool Sattacking = false;
    private float attackTimer = 0;
    private float SattackTimer = 0;
    private float attackCd = 0.2f;
    private float SattackCd = 1.0f;

    public int attackNum = 1;
    public GameObject ProjectileRight, ProjectileLeft;

    //Animation
    private Animator anim;
    private int State = 0;


    // Use this for initialization
    void Start ()
    {
        switch (this.tag)
        {
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
        anim = GetComponent<Animator>();
        anim.SetInteger("State", State);
    }
	
	// Update is called once per frame
	void Update () {

        //Animator state check

        //
        float moveHorizontal = Input.GetAxisRaw(horizontalCtrl);
        transform.position += transform.right * Time.deltaTime * speed * moveHorizontal;

        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
            direction = 1;
        }
        else if (moveHorizontal < 0 && facingRight)
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
            //Jump Animation
            //State = ;
            //anim.SetInteger("State", State);
        }

        /*
         else if (Mathf.Abs(moveHorizontal) >= 0.0001)
        {
            if(attackNum == 1){
                State = 3;//Screwdriver run
                anim.SetInteger("State", State);
            }else if(attackNum == 2)
            {
                State = 3;//Wrench run
                anim.SetInteger("State", State);
            }else if(attackNum == 3)
            {
                State = 3;//Hammer run
                anim.SetInteger("State", State);
            }
        }
        else if(Input.anyKey == false)// && anim != null)//|| Mathf.Abs(moveHorizontal) >= 0
        {
            State = 0;
			//Moving.Stop ();
            anim.SetInteger("State", State);

        }
         */
        if (Input.GetButtonDown(trigger) && !attacking) //&& collisionCheck == true)
        {
            attacking = true;
            attackTimer = attackCd;
            Debug.Log("Basic: " + attackCd);
            speed = 0;
            
            if (attackNum == 1)
            {
                //attack 1
                Fire1();
                anim.SetTrigger("Attack");
            }
            else
            {
                anim.SetTrigger("Attack");
            }
            /*else if(attackNum == 2)
            {
                //attack 2
                Fire2();
                //anim.SetTrigger("WrenchAttack");
            }
            else
            {
                //attack 3
                Fire3();
                //anim.SetTrigger("MalletAttack");
            }
             */
            //Fire();
            //Shooting.Play();
            //anim.SetTrigger("Attack");
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
                speed = 7;
            }
        }
        if (Input.GetButtonDown(special) && !Sattacking)
        {
            //Debug.Log(State);
            SpecialAttack();
            Sattacking = true;
            SattackTimer = SattackCd;
            //anim.SetTrigger("AttackSwitch");
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
    }
    //Attack 1: Screw Driver
    void Fire1()
    {
        anim.SetTrigger("Attack");
        //Projectile attack
        if (facingRight)
        {
            GameObject clone = (GameObject)Instantiate(ProjectileRight, new Vector3(transform.position.x + 1.2f, transform.position.y), transform.rotation);
            Destroy(clone, 2.0f);
            Physics2D.IgnoreCollision(clone.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }

        if (!facingRight)
        {
            GameObject clone = (GameObject)Instantiate(ProjectileLeft, new Vector3(transform.position.x - 1.2f, transform.position.y), transform.rotation);
            Destroy(clone, 2.0f);
            Physics2D.IgnoreCollision(clone.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    //Attack 2
    void Fire2()
    {
        //Melee?
        anim.SetTrigger("Attack");
    }

    //Attack 3
    void Fire3()
    {
        //Do we need another? Maybe knockup?
        anim.SetTrigger("Attack");
    }

    void SpecialAttack()
    {
        //cycle between three attacks
        attackNum = attackNum % 3 + 1;
        Debug.Log(attackNum);
        if (attackNum == 2)
        {
            //attack 1
            attackCd = 0.3f;
            State = 1;
            anim.SetInteger("State", State);
        }
        else if (attackNum == 3)
        {
            //attack 2
            attackCd = 0.5f;
            State = 2;
            anim.SetInteger("State", State);
        }
        else if(attackNum == 1)
        {
            //attack 3
            attackCd = 0.2f;
            State = 0;
            anim.SetInteger("State", State);
        }
        anim.SetInteger("State", State);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
