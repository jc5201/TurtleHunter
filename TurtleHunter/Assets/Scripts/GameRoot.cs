using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System;
using System.IO;

public class GameRoot : MonoBehaviour
{

    public GameObject EnemyAPrefab;
    public GameObject EnemyBPrefab;
    public GameObject EnemyBoss;
    public float interval, distance;
    
    private List<EnemyData> SpawnList = new List<EnemyData>(0);

    private bool BossSpawned = false;
    private bool SpawnFlag = false;
    private Timer SpawnTimer = new Timer();

    private string filename = "EnemyLocation";
    
    public AudioClip NormalBackground;
    public AudioClip BossBackground;
    private AudioSource backAudio;

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
    void Start()
    {
        backAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        SpawnTimer.Elapsed += SpawnTimer_Elapsed;
        SpawnTimer.Interval = interval;
        SpawnTimer.Start();

        TextAsset _txtFile = Resources.Load(filename, typeof(TextAsset)) as TextAsset;
        if (_txtFile.text == null) Debug.Log("text NULL");
        string[] lines = _txtFile.text.Split('\n');
        foreach (string line in lines)
        {
            string[] arr = line.Split(',');
            if (String.Compare(arr[0], "타임")==0) continue;
            SpawnList.Add(new EnemyData(float.Parse(arr[0]), "Enemy" + arr[1], (float)Math.PI / 360 * float.Parse(arr[2]), (float)Math.PI / 360 * float.Parse(arr[3])));

        }

        Spawn();
    }

    private void SpawnTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        SpawnFlag = true;
        SpawnTimer.Enabled = false;
    }

    public void Spawn()
    {
        SpawnTimer.Enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnFlag)
        {
            if (SpawnList.Count != 0)
            {
                switch (SpawnList[0].type)
                {
                    case "EnemyA":
                        Instantiate(EnemyAPrefab, new Vector3(distance * (float)Math.Sin((double)SpawnList[0].theta) * (float)Math.Cos((double)SpawnList[0].pi),
                                                      distance * (float)Math.Sin((double)SpawnList[0].pi),
                                                      distance * (float)Math.Cos((double)SpawnList[0].theta) * (float)Math.Cos((double)SpawnList[0].pi)), Quaternion.identity);
                        break;
                    case "EnemyB":
                        Instantiate(EnemyBPrefab, new Vector3(distance * (float)Math.Sin((double)SpawnList[0].theta) * (float)Math.Cos((double)SpawnList[0].pi),
                                                      distance * (float)Math.Sin((double)SpawnList[0].pi),
                                                      distance * (float)Math.Cos((double)SpawnList[0].theta) * (float)Math.Cos((double)SpawnList[0].pi)), Quaternion.identity);
                        break;
                }
                
                SpawnList.RemoveAt(0);
            }
            else if(!BossSpawned)
            {
                GameObject boss = Instantiate(EnemyBoss, GameObject.Find("Boss_Spawn").transform) as GameObject;
                BossMusic();
                BossSpawned = true;
            }
            SpawnFlag = false;
        }
    }

    public void BossMusic()
    {
        backAudio.clip = BossBackground;
        backAudio.Play();
    }
    public void NormalMusic()
    {
        backAudio.clip = NormalBackground;
        backAudio.Play();
    }
}
