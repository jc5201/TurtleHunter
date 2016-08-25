using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour {


    private GameObject Player;
    public GameObject o_bullet;

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
        Player.transform.rotation = new Quaternion(0, 0, 0, 0);
        Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        //플레이어 회전
        Player.transform.Rotate(-1 * Input.gyro.rotationRateUnbiased.x, -1 * Input.gyro.rotationRateUnbiased.y, Input.gyro.rotationRateUnbiased.z);
        Touched();
    }

    void Touched()//터치 관련 함수
    {
        if (Input.touchCount >= 1)
        //if(Input.GetMouseButton(0))//임시방편 마우스 클릭
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //Handheld.Vibrate();
                Instantiate(o_bullet, Player.transform.position, Player.transform.rotation);
            }
            //Debug.Log("Touchded");
        }
    }
}
