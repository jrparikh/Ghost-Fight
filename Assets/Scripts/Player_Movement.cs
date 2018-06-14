using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public float speed;             //Floating point variable to store the player's movement speed.

    public Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Trigger");
        if (col.gameObject.tag == "Bookshelf")
        {
            //if (Input.GetKeyDown("space"))
            {
                Debug.Log("Trigger");
                sprite.enabled = false;
            }
        }
    }
}