﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int HP = 5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if(HP <= 0)
        {
            //게임오버
        }
	}
}
