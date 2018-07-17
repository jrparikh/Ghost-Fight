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
        Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void Update()
    {
        this.rb.velocity = new Vector2(VelX, VelY);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bookshelf")
        {
            return;
        }else
        {
            //other.gameObject.GetComponent<Chair>().CurrentHP -= damage;
            DestroyObject(other.gameObject);
            Destroy(gameObject);
        }
    }
}
