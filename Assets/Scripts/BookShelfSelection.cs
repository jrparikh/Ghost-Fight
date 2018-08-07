using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfSelection : MonoBehaviour {
	public Sprite mySprite1;
	public Sprite mySprite2;
	public GameObject myGameObj1;
	public GameObject myGameObj2;

	void OnTriggerEnter2D(Collider2D col)
	{
		print ("here");

		if (PlayerSelection.MinPlayersIn < 2) {

			if (Input.GetKey (KeyCode.Q)) {
				
				PlayerSelection.Player1 = "Bookshelf";
				myGameObj1.GetComponent<SpriteRenderer>().sprite = mySprite1;
				PlayerSelection.MinPlayersIn++;
			}
			//////////////////////////////////
			if (Input.GetKey (KeyCode.O)){
			    PlayerSelection.Player2 = "Bookshelf";
				myGameObj2.GetComponent<SpriteRenderer>().sprite = mySprite2;
				PlayerSelection.MinPlayersIn++;
			}
		}
	}
}
