using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int HP;

	// Use this for initialization
	void Start () {
        HP = 5;
	}
	
	// Update is called once per frame
	void Update () {
	    if(HP <= 0)
        {
            //게임오버
        }
	}
}
