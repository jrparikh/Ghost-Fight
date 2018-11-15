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
    private float attackCd = 0.25f;
    private float SattackCd = 0.90f;

    public int attackNum = 1;
    //


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
    }
	
	// Update is called once per frame
	void Update () {
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
        }
        if (Input.GetButtonDown(trigger) && !attacking) //&& collisionCheck == true)
        {
            attacking = true;
            attackTimer = attackCd;

            if (attackNum == 1)
            {
                //attack 1
            }else if(attackNum == 2)
            {
                //attack 2
            }
            else
            {
                //attack 3
            }

                Fire();
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
            }
        }
        if (Input.GetButtonDown(special) && !Sattacking)
        {
            SpecialAttack();
            Sattacking = true;
            SattackTimer = SattackCd;
            //Shotgun.Play();
            //anim.SetTrigger("Attack");
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
    void Fire()
    {
        //have to figure out three attacks
    }

    void SpecialAttack()
    {
        //cycle between three attacks
        attackNum = attackNum % 3 + 1;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
