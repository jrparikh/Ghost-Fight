using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour {
    public float speed;
    public bool collisionCheck = false;
    public string jumpButton = "Jump_P1";
    public string horizontalCtrl = "Horizontal_P1";
    public string trigger = "Fire_P1";

    //Fighting
    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.3f;
    public Collider2D attackTrigger;

    public bool facingRight = true;

    public int MaxHP = 100;
    public int CurrentHP = 100;

    public Vector2 jumpHeight;

    public bool isGrounded = true;

    void Start () {
        attackTrigger.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis(horizontalCtrl);
        //float jump = Input.GetAxis("Jump_P1");
        //float moveVertical = Input.GetAxis("Vertical");
        transform.position += transform.right * Time.deltaTime * speed * moveHorizontal;
        //transform.position += transform.up * Time.deltaTime * speed * moveVertical;

        if (moveHorizontal > 0 && !facingRight)
            Flip();
        else if (moveHorizontal < 0 && facingRight)
            Flip();
        if (Input.GetButtonDown(jumpButton) && isGrounded)
        {
            //speed = 0;
            //collisionCheck = false;
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
        }

            if (Input.GetButtonDown(trigger) && !attacking)
            {
                attacking = true;
                attackTimer = attackCd;

                attackTrigger.enabled = true;
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
        if (col.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }
}
