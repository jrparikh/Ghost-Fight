using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float VelX = 0f;
    public float VelY = 5f;
    Rigidbody2D rb;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.rb.velocity = new Vector2(VelX, VelY);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.tag == "Enemy")
        {
            //other.gameObject.GetComponent<Chair>().CurrentHP -= damage;
            //DestroyObject(other.gameObject);
            //Destroy(gameObject);
        }
    }
}
