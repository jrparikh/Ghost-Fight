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
    
    private string horizontalCtrl = "Horizontal_P2";
    private string verticalCtrl = "Vertical_P2";
    // Use this for initialization
    void Start () {
        switch (this.tag)
        {
            case "Player1":
                //put controls here
                horizontalCtrl = "Horizontal_P1";
                verticalCtrl = "Vertical_P1";
                break;
            case "Player2":
                //put controls here
                horizontalCtrl = "Horizontal_P2";
                verticalCtrl = "Vertical_P2";
                break;

        }
    }
	// Update is called once per frame
	void Update () {
		//GetInput ();
        float moveHorizontal = Input.GetAxisRaw(horizontalCtrl);
        float moveVertical = Input.GetAxisRaw(verticalCtrl);
        transform.position += transform.right * Time.deltaTime * speed * moveHorizontal;
        transform.position += transform.up * Time.deltaTime * speed * moveVertical;
       // Move();
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
