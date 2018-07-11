using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour {
    public float speed;
    public bool collisionCheck = false;

    //Fighting
    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.3f;
    public Collider2D attackTrigger;

    public Vector2 jumpHeight;

    void Start () {
        attackTrigger.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        transform.position += transform.right * Time.deltaTime * speed * moveHorizontal;
        //transform.position += transform.up * Time.deltaTime * speed * moveVertical;

        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0"))
        {
            //speed = 0;
            //collisionCheck = false;
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }

        if (collisionCheck == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !attacking)
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
    }
    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            speed = 10;
            collisionCheck = true;
        }
    }*/
}
