using UnityEngine;
using System.Collections;

public class Input2 : MonoBehaviour {

    public GameObject o_bullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount == 1)//터치
        //if(Input.GetMouseButton(0))//임시방편 마우스 클릭
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
                Instantiate(o_bullet);
            Debug.Log("Touchded");
        }
    }
    void Touched()
    {

    }
}
