using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public enum State{ MOVE, NONE, DESTROY };
    State Enemy_State;
	// Use this for initialization
	void Start () {
        transform.LookAt(GameObject.Find("Player").transform);
    }
	
	// Update is called once per frame
	void Update () {
	}

}
