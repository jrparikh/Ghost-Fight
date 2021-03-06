﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {

	public Sprite mySprite1;
    //public Sprite mySprite2;
    public GameObject redBorder;
    public GameObject blueBorder;
    public GameObject diagBorder;
    public GameObject myGameObj1;
	public GameObject myGameObj2;
	public GameObject Player1;
	public GameObject Player2;
    public Animator anim;

    public ParticleSystem ps;
	public float PosY;   
	public float ScaleX;
	public float ScaleY;  
	public float ScaleZ;  
	public string CharacterName;
	public bool Player1Enter = false;
	public bool Player2Enter = false;
	private string jumpButton = "Fire_P1";
	private string jumpButton2 = "Fire_P2";
	// Use this for initialization
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
	void Update (){
        if (Player1Enter == true)
        {
            redBorder.SetActive(true);

            if (Input.GetButton(jumpButton))
            {                
                anim.SetTrigger("Player1");
                PlayerSelection.Player1 = CharacterName;
                myGameObj1.GetComponent<SpriteRenderer>().sprite = mySprite1;
                myGameObj1.transform.position = new Vector3(myGameObj1.transform.position.x, PosY, myGameObj1.transform.position.z);
                myGameObj1.transform.localScale = new Vector3(ScaleX, ScaleY, ScaleZ);
                PlayerSelection.MinPlayersIn++;
                Player1.GetComponent<CursorMovement>().speed = 0;
                Player1Enter = false;
            }
        }
        else //if (Player1Enter == false)
        {
            redBorder.SetActive(false);
            diagBorder.SetActive(false);
        }

        if (Player2Enter == true) {
            blueBorder.SetActive(true);
            
            if (Input.GetButton(jumpButton2))
            {
                anim.SetTrigger("Player2");
                PlayerSelection.Player2 = CharacterName;
				myGameObj2.GetComponent<SpriteRenderer> ().sprite = mySprite1;
				myGameObj2.transform.position = new Vector3(myGameObj2.transform.position.x,PosY, myGameObj2.transform.position.z);
				myGameObj2.transform.localScale = new Vector3(-ScaleX,ScaleY, ScaleZ);
				PlayerSelection.MinPlayersIn++;
				Player2.GetComponent<CursorMovement> ().speed = 0;
				Player2Enter = false;
			}

        }
        else //if (Player2Enter == false)
        {
            blueBorder.SetActive(false);
            diagBorder.SetActive(false);
        }

        if (Player1Enter == true && Player2Enter == true)
        {
            diagBorder.SetActive(true);
            redBorder.SetActive(false);
            blueBorder.SetActive(false);
        }
    }
	void OnTriggerEnter2D(Collider2D col)
	{


		if (PlayerSelection.MinPlayersIn < 2) {
			if (col.gameObject.tag == "Player1") {
				Player1Enter = true;
			}
			if (col.gameObject.tag == "Player2") {
				Player2Enter = true;
			}
			//////////////////////////////////

		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player1") {
			Player1Enter = false;
		}
		if (col.gameObject.tag == "Player2") {
			Player2Enter = false;
		}
	}


}
