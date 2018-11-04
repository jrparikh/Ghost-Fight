using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
	public float Myhealth = 100f ;
	private float CurrentHealth;
	public SpriteRenderer healthBar;
	private Vector3 healthScale;
	public AudioSource Hit;
	public bool Damaged;
	private float DmgTimer = 0;
	private float DmgCd = 0.3f;
	public SpriteRenderer Damage;
	private Renderer MySprite;
	public Color Red = Color.white;
	// Use this for initialization
	void Start () {
		switch (this.tag) {
		case "Player1":
			healthBar = GameObject.Find ("HealthBar1").GetComponent<SpriteRenderer> ();
			break;
		case "Player2":
			healthBar = GameObject.Find ("HealthBar2").GetComponent<SpriteRenderer> ();
			break;
		}
		MySprite = GetComponent<Renderer>();
		healthScale = healthBar.transform.localScale;
		CurrentHealth = Myhealth;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateHealthBar();
		if (CurrentHealth != Myhealth) {
			Hit.Play ();
			Damaged = true;
		}
		//Display Damaged indicator
		if (Damaged == true) {
			DmgTimer = DmgCd;
			Damaged = false;
			MySprite.material.color = Red; 
		}
		if (DmgTimer > 0) {
			DmgTimer -= Time.deltaTime;
		} 

		else {
			MySprite.material.color = Color.white; 

		}

		if (Myhealth <= 0)
		{
			Death();
		}
		CurrentHealth = Myhealth;
	}

	public void UpdateHealthBar()
	{
			// Set the health bar's colour to proportion of the way between green and red based on the player's health.
		healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - Myhealth * 0.01f);

			// Set the scale of the health bar to be proportional to the player's health.
		healthBar.transform.localScale = new Vector3(healthScale.x * Myhealth * 0.01f, 1, 1);
	}
	void Death()
	{
		//Destroy(gameObject);
		SceneManager.LoadScene("Test");
	}
}
