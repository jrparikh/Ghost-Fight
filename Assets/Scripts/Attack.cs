﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.tag == "Enemy")
        {
            //other.gameObject.GetComponent<Chair>().CurrentHP -= damage;
            DestroyObject(other.gameObject);
            Destroy(gameObject);
        }
    }
}
