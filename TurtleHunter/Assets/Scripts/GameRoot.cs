﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System;

public class GameRoot : MonoBehaviour {

    public GameObject EnemyPrefab;
    public float interval, distance;

    private List<KeyValuePair<float, float>> SpawnList = new List<KeyValuePair<float, float>>(0);

    private Timer SpawnTimer = new Timer();
    private bool SpawnFlag = false;

	// Use this for initialization
	void Start () {
        SpawnTimer.Elapsed += SpawnTimer_Elapsed;
        SpawnTimer.Interval = interval;
        SpawnTimer.Start();

        //List 초기화
        SpawnList.Add(new KeyValuePair<float, float>(0, 0));
        SpawnList.Add(new KeyValuePair<float, float>((float)Math.PI / 6, 0));   
        SpawnList.Add(new KeyValuePair<float, float>((float)Math.PI / 3, 0));
        
    }

    private void SpawnTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        SpawnFlag = true;
    }

    // Update is called once per frame
    void Update () {

        if (SpawnFlag)
        {
            if (SpawnList.Count != 0)
            {
                Instantiate(EnemyPrefab, new Vector3( distance * (float)Math.Sin((double)SpawnList[0].Key) * (float)Math.Cos((double)SpawnList[0].Value), distance * (float)Math.Sin((double)SpawnList[0].Key) * (float)Math.Sin((double)SpawnList[0].Value), distance * (float)Math.Cos((double)SpawnList[0].Key)), Quaternion.identity);
                SpawnList.RemoveAt(0);
            }
            else
            {
                SpawnTimer.Stop();
            }
            SpawnFlag = false;
        }
    }
}
