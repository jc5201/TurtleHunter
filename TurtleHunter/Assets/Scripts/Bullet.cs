﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public enum State { MOVE, NONE, DESTROY };
    State Bullet_State;
    private Transform _player;
    BoxCollider _collider;
    float _size;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _collider = GetComponent<BoxCollider>();
        _size = 1.0f;
        Bullet_State = State.MOVE;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Bullet_State)
        {
            case State.MOVE:
                Bullet_Move();
                break;
            case State.DESTROY:
                Bullet_Destroy();
                break;
            case State.NONE:
                break;
        }
        if (_size > 20.0f)
            Bullet_State = State.DESTROY;
    }
    void Bullet_Move()
    {
        //Vector3 dir = _player.transform.position - this.transform.position;
        //this.transform.LookAt(_player.transform.position);
        //this.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
        _size += 0.1f;
        transform.Translate(transform.forward);
        _collider.size = new Vector3(_size, _size, 1.0f);
    }
    void Bullet_Destroy()
    {
        Destroy(this.gameObject);
    }
}
