using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairSelection : MonoBehaviour {
	public Sprite mySprite1;
	//public Sprite mySprite2;
	public GameObject myGameObj1;
	public GameObject myGameObj2;
	public GameObject Player1;
	public GameObject Player2;
	public bool Player1Enter = false;
	public bool Player2Enter = false;
	// Use this for initialization
	void Update (){
		if (Player1Enter == true) {
			if (Input.GetKeyDown (KeyCode.Q)) {
				PlayerSelection.Player1 = "Chair";
				myGameObj1.GetComponent<SpriteRenderer> ().sprite = mySprite1;
				PlayerSelection.MinPlayersIn++;
				Player1.GetComponent<CursorMovement> ().speed = 0;
				Player1Enter = false;
			}
		}
		if (Player2Enter == true) {
			if (Input.GetKeyDown (KeyCode.O)) {
				PlayerSelection.Player2 = "Chair";
				myGameObj2.GetComponent<SpriteRenderer> ().sprite = mySprite1;
				PlayerSelection.MinPlayersIn++;
				Player2.GetComponent<CursorMovement> ().speed = 0;
				Player2Enter = false;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{


		if (PlayerSelection.MinPlayersIn < 2) {
			if (col.gameObject.tag == "Player1") {
				Player1Enter = true;
			}
			if (col.gameObject.tag == "Player2") {
				Player2Enter = true;
			}
			//////////////////////////////////

		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player1") {
			Player1Enter = false;
		}
		if (col.gameObject.tag == "Player2") {
			Player2Enter = false;
		}
	}
	

}
