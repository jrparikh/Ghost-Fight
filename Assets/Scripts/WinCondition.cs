using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour {

	public static List<GameObject> players = new List<GameObject>(); 
	public static bool End = false;
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
			End = true;
			if (players.Count != 0) {
				GameObject.Find ("WinText").GetComponent<Text>().text = players [0].tag + " wins";

			} 
			else {
				GameObject.Find ("WinText").GetComponent<Text>().text = "DRAW";
			}
			StartCoroutine(DelayGame());
		}
	}

	IEnumerator DelayGame(){
		yield return new WaitForSeconds(3);
		End = false;
		players.Clear ();
        CameraFollow.players.Clear();
        SceneManager.LoadScene("Test");
	}

}
