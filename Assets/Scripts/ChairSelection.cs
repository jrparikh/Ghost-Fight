using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairSelection : MonoBehaviour {
	public Sprite mySprite1;
	public Sprite mySprite2;
	public GameObject myGameObj1;
	public GameObject myGameObj2;
	// Use this for initialization
	void OnMouseDown()
	{
		if (PlayerSelection.MinPlayersIn == false) {
			PlayerSelection.Player1 = "Chair";
			myGameObj1.GetComponent<SpriteRenderer>().sprite = mySprite1;
			PlayerSelection.Player2 = "Bookshelf";
			myGameObj2.GetComponent<SpriteRenderer>().sprite = mySprite2;
			PlayerSelection.MinPlayersIn = true;
		}
	}
	

}
