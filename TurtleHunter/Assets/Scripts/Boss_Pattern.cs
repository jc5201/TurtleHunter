using UnityEngine;
using System.Collections;

public class Boss_Pattern : MonoBehaviour {
    // Use this for initialization
    //Hashtable hs;
    GameObject player;
    public GameObject Spawn_Enemy;
    private Transform Spawn_Position;
    //public Transform[3] SpawnPosition;

    void Start()
    {
        player = GameObject.Find("Player");
        Spawn_Position = GameObject.Find("EnemySpot").transform;
        Horizon();
       // for(int i = 0; i < 4; i++)
            //GameObject obj = Instantiate(Spawn_Enemy,SpawnPosition[i]) as GameObject;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }
    void Horizon()
    {
        iTween.MoveTo(gameObject, iTween.Hash("Path", iTweenPath.GetPath("Boss_Path_Horizon"),"Time", 20f,"oncomplete","Vertical"));
        Instantiate(Spawn_Enemy, Spawn_Position);
    }
    void Vertical()
    {
        iTween.MoveTo(gameObject, iTween.Hash("Path", iTweenPath.GetPath("Boss_Path_Vertical"), "Time", 20f, "oncomplete","Move_Up"));
        Instantiate(Spawn_Enemy, Spawn_Position);
    }
    void Move_Up()
    {
        iTween.MoveTo(gameObject, iTween.Hash("Path", iTweenPath.GetPath("Boss_Path_Up"), "Time", 20f,"oncomplete", "Move_Down"));
        Instantiate(Spawn_Enemy, Spawn_Position);
    }
    void Move_Down()
    {
        iTween.MoveTo(gameObject, iTween.Hash("Path", iTweenPath.GetPath("Boss_Path_Down"), "Time", 20f));
        Instantiate(Spawn_Enemy, Spawn_Position);
    }
}
