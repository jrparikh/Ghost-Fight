using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float speed;             //Floating point variable to store the player's movement speed.
    private SpriteRenderer sprite;
    //public Collider2D coll;

    public GameObject player;
    private Transform col;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        //coll = GetComponent<Collider2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
        //float dx = moveHorizontal * speed;
        //float dy = moveVertical * speed;
        //transform.position = new Vector2(transform.position.x + dx, transform.position.y + dy);
        transform.position += transform.right * Time.deltaTime * speed * moveHorizontal;
        transform.position += transform.up * Time.deltaTime * speed * moveVertical;
        if (Input.GetKeyDown("space"))
        {
            //Debug.Log("Trigger");
            sprite.enabled = true;
            //rb2d.isKinematic = false;
            GetComponent<Collider2D>().enabled = true;
            //player.transform.SetParent(null);
            transform.transform.parent = null;
            transform.position += transform.right * moveHorizontal * speed;
            speed = 10;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Bookshelf")
            transform.transform.parent = col.transform;
        if (col.gameObject.tag == "Chair")
            transform.transform.parent = col.transform;
        //if (Input.GetKeyDown("space"))
        {
                //Debug.Log("Trigger");
                sprite.enabled = false;
                GetComponent<Collider2D>().enabled = false;
                //player.GetComponent<Transform>().SetParent(col.collider.Bookshelf);
                speed = 0;
            }
        
    }
}