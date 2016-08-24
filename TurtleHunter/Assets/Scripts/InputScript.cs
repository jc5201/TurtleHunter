using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour {


    GameObject Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Player.transform.Rotate(-1 * Input.gyro.rotationRateUnbiased.x, -1 * Input.gyro.rotationRateUnbiased.y, Input.gyro.rotationRateUnbiased.z);
	}
}
