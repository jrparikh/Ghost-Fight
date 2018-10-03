using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
	public float Myhealth = 100f ;
	public SpriteRenderer healthBar;
	private Vector3 healthScale;
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
		healthScale = healthBar.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateHealthBar();
		if (Myhealth <= 0)
		{
			Death();
		}
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
