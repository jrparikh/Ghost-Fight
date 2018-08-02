using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Spawn : MonoBehaviour {
	public GameObject Player1HP;
	GameObject Player1Clone;

    // Use this for initialization
	void Start () {
		Player1Clone = Instantiate (Resources.Load(PlayerSelection.Player1), transform.position, Quaternion.identity) as GameObject;
		MonoBehaviour script = (MonoBehaviour)Player1Clone.GetComponent(PlayerSelection.Player1);
		script.enabled = true;
		Player1HP.GetComponent<FollowPlayer> ().player = Player1Clone.transform;
		Destroy (gameObject);


	}
}
