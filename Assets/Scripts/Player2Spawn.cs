using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Spawn : MonoBehaviour {
	public GameObject Player2HP;
	GameObject Player2Clone;

	// Use this for initialization
	void Start () {
		Player2Clone = Instantiate (Resources.Load(PlayerSelection.Player2), transform.position, Quaternion.identity) as GameObject;
		MonoBehaviour script = (MonoBehaviour)Player2Clone.GetComponent(PlayerSelection.Player2);
		script.enabled = true;
		Player2Clone.tag = "Player2";
		Player2HP.GetComponent<FollowPlayer>().player = Player2Clone.transform;
		Destroy (gameObject);


	}
}
