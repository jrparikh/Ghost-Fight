using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerSelection : MonoBehaviour {
	public static string Player1;
	public static string Player2;
	public static int MinPlayersIn = 0;
	public GameObject Text1;
	public Sprite mySprite;
	public Sprite mySprite1;
	public Sprite mySprite2;
	public GameObject myGameObj1;
	public GameObject myGameObj2;
	// Update is called once per frame
	void Update () {
		if (MinPlayersIn == 2) {
			Text1.GetComponent<SpriteRenderer>().sprite = mySprite;
			if (Input.GetKeyDown (KeyCode.Space)) {
				MinPlayersIn = 0;
				SceneManager.LoadScene("Test");
			}
			if (Input.GetKeyDown (KeyCode.Escape)) {
				MinPlayersIn = 0;
				Text1.GetComponent<SpriteRenderer>().sprite = null;
				myGameObj1.GetComponent<SpriteRenderer>().sprite = mySprite1;
				myGameObj2.GetComponent<SpriteRenderer>().sprite = mySprite2;
				Player1 = null;
				Player2 = null;

			}
			//if button pressed down go to game screen

		} 

	}
}
