using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float VelX = 15f;
    public float VelY = 0f;
    Rigidbody2D rb;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        //Physics.IgnoreCollision(.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void Update()
    {
        this.rb.velocity = new Vector2(VelX, VelY);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        var magnitude = 3;
        // calculate force vector
        var force = transform.position - other.transform.position;
        // normalize force vector to get direction only and trim magnitude
        //force.Normalize();
        gameObject.GetComponent<Rigidbody2D>().AddForce(-force * magnitude);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
