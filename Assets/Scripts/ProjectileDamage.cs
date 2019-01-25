using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour {
	public float Damage;
	public string ParentString;
	//public AudioSource Hit;
	/*
	public SpriteRenderer FX;
	public bool attacking;
	public float attackTimer = 0.25f;
	*/
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		/*
		if (attacking == true) {
			attackTimer = 0.25f;
			attacking = false;
		}
		if (attackTimer > 0)
		{
			attackTimer -= Time.deltaTime;
		}
		else
		{
			FX.enabled = false;
		}
		*/
	}
	//Trigger object with box collider Trigger on
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Contains ("Player")) {
			//Hit.Play ();
			/*
			FX.enabled = true;
			attacking = true;
			if (col.gameObject.tag != this.tag) {
				
			}
			*/
			col.gameObject.GetComponent<Health> ().Myhealth -= Damage;

		}
		if (this.tag == "projectile") {
			Destroy (gameObject);
		}

	}
	//Collison with projectiles that dont have trigger
	void OnCollisionEnter2D(Collision2D col)
	{
		print ("here");
		if (col.gameObject.tag.Contains ("Player")) {
			//Hit.Play ();
			/*
			FX.enabled = true;
			attacking = true;
			*/
			if (col.gameObject.tag != ParentString) {
				col.gameObject.GetComponent<Health> ().Myhealth -= Damage;
				print (col.gameObject.GetComponent<Health> ().Myhealth);
			}

			if (this.tag == "InstantDelete") {
				Destroy (gameObject);
			}
		}
		if (this.tag == "projectile") {
			
			Destroy (gameObject);
		}
	}
}