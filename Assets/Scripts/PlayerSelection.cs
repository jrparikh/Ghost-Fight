using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour {
	public static string Player1;
	public static string Player2;
	// Use this for initialization
	void Start () {
		Player1 = null;
		Player2 = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (Player1 != null && Player2 != null) {
			//if button pressed down go to game screen
		} 

	}
}
