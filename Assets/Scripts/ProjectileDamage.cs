using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour {
	public float Damage; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Contains ("Player")) {
			col.gameObject.GetComponent<Health>().Myhealth -= Damage;
			if (this.tag == "projectile") {
				Destroy (gameObject);
			}
		}
	}
}
