using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour {
	public string upKey;
	public string downKey;
	public string leftKey;
	public string rightKey;
	public float  speed;
	public Vector2  direction;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		GetInput ();
		Move ();
	}
	private void Move(){
		transform.Translate (direction * speed * Time.deltaTime);
	}
	private void GetInput(){
		direction = Vector2.zero;
		if (Input.GetKey (upKey)) {
			direction += Vector2.up;
		}
		if (Input.GetKey (downKey)) {
			direction += Vector2.down;
		}
		if (Input.GetKey (leftKey)) {
			direction += Vector2.left;
		}
		if (Input.GetKey (rightKey)) {
			direction += Vector2.right;
		}
	}
}
