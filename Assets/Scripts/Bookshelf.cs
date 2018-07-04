using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb2d;

    public GameObject Projectile;
    public float fireSpeed;
    public float fireRate;
    public bool collisionCheck = false;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        transform.position += transform.right * Time.deltaTime * speed * moveHorizontal;
        transform.position += transform.up * Time.deltaTime * speed * moveVertical;

        if (Input.GetKeyDown("space"))
        {
            speed = 0;
            collisionCheck = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && collisionCheck == true)
        {
            Fire();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        speed = 10;
        collisionCheck = true;
    }
    void Fire()
    {
        fireRate = Time.time + fireSpeed;
        GameObject clone = (GameObject)Instantiate(Projectile, transform.position, transform.rotation);
        Destroy(clone, 2.0f);
    }
}
