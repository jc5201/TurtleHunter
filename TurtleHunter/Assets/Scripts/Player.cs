using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour {

    public int HP = 5;
    public GameObject[] HP_Bar;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if(HP <= 0)
        {
            //게임오버
        }
        switch(HP)
        {
            case 0:
                HP_Bar[0].SetActive(false);
                break;
            case 1:
                HP_Bar[1].SetActive(false);
                break;
            case 2:
                HP_Bar[2].SetActive(false);
                break;
            case 3:
                HP_Bar[3].SetActive(false);
                break;
            case 4:
                HP_Bar[4].SetActive(false);
                break;
        }
	}
}
