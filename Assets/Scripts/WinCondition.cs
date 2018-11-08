using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

	public static List<GameObject> players = new List<GameObject>(); 
	// Use this for initialization
	void Start () {
		

    }
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject player in players) {
			if (player.GetComponent<Health> ().Myhealth < 0) {
				string currentTag = player.tag;
				switch (currentTag) {
				case "Player1":
					Destroy (GameObject.Find ("Player1Health"));
					break;
				case "Player2":
					Destroy (GameObject.Find ("Player2Health"));
					break;

				}
				players.Remove (player);
				Destroy(GameObject.FindGameObjectWithTag(currentTag));
			}
		}
		if (players.Count <= 1) {
			if (players.Count != 0) {
				print ("You win!");
			} 
			else {
				print ("tie");
			}
		}
	}
}
