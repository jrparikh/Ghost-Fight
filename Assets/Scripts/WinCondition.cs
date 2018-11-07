using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

	public float[] players;
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 2; i++) {
			string Player;
			Player = "Player"+ i.ToString ();
			print (Player); 
		}

	}
}
