using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System;
using System.IO;

public class GameRoot : MonoBehaviour {

    public GameObject EnemyPrefab;
    public float interval, distance;

    //private List<KeyValuePair<float, float>> SpawnList = new List<KeyValuePair<float, float>>(0);
    private List<EnemyData> SpawnList = new List<EnemyData>(0);

    private Timer SpawnTimer = new Timer();
    private bool SpawnFlag = false;

    public string filename = "EnemyLocation.csv";
    private StreamReader reader;

    private struct EnemyData
    {
        public float time;
        public string type;
        public float theta;
        public float pi;

        public EnemyData(float time, string type, float theta, float pi)
        {
            this.time = time;
            this.type = type;
            this.theta = theta;
            this.pi = pi;
        }
    }

    // Use this for initialization
    void Start () {
        SpawnTimer.Elapsed += SpawnTimer_Elapsed;
        SpawnTimer.Interval = interval;
        SpawnTimer.Start();
        
        
        
        reader = new StreamReader(filename);
        string[] lines = reader.ReadToEnd().Split('\n');
        foreach(string line in lines)
        {
            string[] arr = line.Split(',');
            SpawnList.Add(new EnemyData(float.Parse(arr[0]), "Enemy"+arr[1], float.Parse(arr[2]), float.Parse(arr[3])));
            
        }
        
    
        /*
        //List 초기화
        SpawnList.Add(new KeyValuePair<float, float>(0, 0));
        SpawnList.Add(new KeyValuePair<float, float>((float)Math.PI / 360 * -15, (float)Math.PI / 360 * 15));
        SpawnList.Add(new KeyValuePair<float, float>((float)Math.PI / 360 * 15, (float)Math.PI / 360 * -15));
        SpawnList.Add(new KeyValuePair<float, float>((float)Math.PI / 360 * 15, (float)Math.PI / 360 * 15));
        SpawnList.Add(new KeyValuePair<float, float>((float)Math.PI / 360 * -30, 0));
        SpawnList.Add(new KeyValuePair<float, float>((float)Math.PI / 360 * -60, 0));
        SpawnList.Add(new KeyValuePair<float, float>((float)Math.PI / 360 * -90, 0));
        SpawnList.Add(new KeyValuePair<float, float>(0, 0));
        SpawnList.Add(new KeyValuePair<float, float>((float)Math.PI / 360 * 30, 0));
        SpawnList.Add(new KeyValuePair<float, float>((float)Math.PI / 360 * 60, 0));
        SpawnList.Add(new KeyValuePair<float, float>((float)Math.PI / 360 * 90, 0));
        SpawnList.Add(new KeyValuePair<float, float>(0, 0));
        SpawnList.Add(new KeyValuePair<float, float>(0, (float)Math.PI / 360 * 30));
        SpawnList.Add(new KeyValuePair<float, float>(0, (float)Math.PI / 360 * 60));
        SpawnList.Add(new KeyValuePair<float, float>(0, (float)Math.PI / 360 * 90));
        SpawnList.Add(new KeyValuePair<float, float>(0, (float)Math.PI / 360 * 60));
        SpawnList.Add(new KeyValuePair<float, float>(0, (float)Math.PI / 360 * 30));
        SpawnList.Add(new KeyValuePair<float, float>(0, 0));
        SpawnList.Add(new KeyValuePair<float, float>(0, (float)Math.PI / 360 * -30));
        SpawnList.Add(new KeyValuePair<float, float>(0, (float)Math.PI / 360 * -60));
        SpawnList.Add(new KeyValuePair<float, float>(0, (float)Math.PI / 360 * -90));
        SpawnList.Add(new KeyValuePair<float, float>(0, 0));
        */
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
                Instantiate(EnemyPrefab, new Vector3( distance * (float)Math.Sin((double)SpawnList[0].theta) * (float)Math.Cos((double)SpawnList[0].pi), 
                                                      distance * (float)Math.Cos((double)SpawnList[0].theta) * (float)Math.Sin((double)SpawnList[0].pi), 
                                                      distance * (float)Math.Cos((double)SpawnList[0].theta)), Quaternion.identity);
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
