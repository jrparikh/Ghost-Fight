using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairSelection : MonoBehaviour {
	public Sprite mySprite1;
	public Sprite mySprite2;
	public GameObject myGameObj1;
	public GameObject myGameObj2;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col)
	{
		if (PlayerSelection.MinPlayersIn == 2) {
			if (col.CompareTag ("Player1")) {
				PlayerSelection.Player1 = "Chair";
				myGameObj1.GetComponent<SpriteRenderer> ().sprite = mySprite1;
			}
			PlayerSelection.Player2 = "Bookshelf";
			myGameObj2.GetComponent<SpriteRenderer>().sprite = mySprite2;

		}
	}
	

}
