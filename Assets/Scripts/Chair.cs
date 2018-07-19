using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public float health = 100f;
    public float damageAmount = 10f;
    public SpriteRenderer healthBar;
    private Vector3 healthScale;

    public Vector2 jumpHeight;

    public bool isGrounded = true;

    void Start () {
        attackTrigger.enabled = false;
    }

    void Awake()
    {
        healthScale = healthBar.transform.localScale;
    }

    // Update is called once per frame
    void Update () {
        float moveHorizontal = Input.GetAxisRaw(horizontalCtrl);
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

            if (health <= 0)
            {
                Death();
            }
        
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void TakeDamage()
    {
        health -= damageAmount;
    }

    public void UpdateHealthBar()
    {
        // Set the health bar's colour to proportion of the way between green and red based on the player's health.
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);

        // Set the scale of the health bar to be proportional to the player's health.
        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
    }

    void Death()
    {
        //Destroy(gameObject);
        SceneManager.LoadScene("Test");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            TakeDamage();
            UpdateHealthBar();
        }
        else if (col.gameObject.name == "attackTrigger")
        {
            Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
        else
        {
            //TakeDamage();
            //UpdateHealthBar();
        }
    }
}
