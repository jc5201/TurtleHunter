using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {
    private GameObject _Enemy;
	// Use this for initialization
	void Start () {
        _Enemy = GameObject.FindGameObjectWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
        if(!_Enemy)
        {
        }
    }
}
