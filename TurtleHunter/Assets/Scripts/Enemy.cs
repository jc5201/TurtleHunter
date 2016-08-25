﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public enum State{ MOVE, NONE, DESTROY };
    State Enemy_State;
    public bool b_isExist;
    private GameObject Arrow_Position;
    public GameObject Arrow;
    public int Enemy_HP;
    private GameObject _Player;
    private GameObject obj;
    private AudioSource pAudio;
    public AudioClip s_Destroyed;
    public GameObject Effect_Destroyed;
    private float Att_time;
    // Use this for initialization
    void Start () {
        pAudio = GetComponent<AudioSource>();
        switch (this.tag)
        {
            case "Enemy":
                Enemy_HP = 1;
                break;
            case "Boss":
                Enemy_HP = 3;
                break;
        }
        _Player = GameObject.Find("Player");
        Arrow_Position = GameObject.Find("ArrowPosition");
        obj = Instantiate(Arrow, Arrow_Position.transform.position, Arrow_Position.transform.rotation) as GameObject;
        obj.transform.parent = Arrow_Position.transform;
    }
	// Update is called once per frame
	void Update () {
        if (!gameObject.GetComponent<MeshRenderer>().isVisible)
        {
            Debug.Log("invisible!");
            //나중에 이부분에 화살표도 안보이도록 설정할것!
        }
        if (Enemy_HP <= 0)
        {
            Delete();
        }
        else
        {
            Att_time += Time.deltaTime;
            if (this.CompareTag("Enemy"))
            {
                if (Att_time > 4.0f)
                {
                    Att_time = 0;
                    Delete();
                }
            }
            obj.transform.LookAt(this.transform);
            transform.LookAt(_Player.transform);
            //transform.Translate(this.transform.localPosition * 0.005f);
            GetComponent<Rigidbody>().AddForce(this.transform.forward * 0.01f, ForceMode.VelocityChange);
        }
    }
    public void Delete()
    {
        GameObject eff = Instantiate(Effect_Destroyed, transform.position, Quaternion.identity) as GameObject;
        Destroy(eff, 2f);
        GameObject.Find("GameRoot").GetComponent<GameRoot>().Spawn();
        pAudio.PlayOneShot(s_Destroyed);
        pAudio.volume = 10.0f;
        pAudio.spatialBlend = 0;
        
        Destroy(obj);
        Destroy(this.gameObject);
    }
}
