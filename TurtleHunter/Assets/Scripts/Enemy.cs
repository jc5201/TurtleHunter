using UnityEngine;
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
    public AudioClip s_Cleared;
    public GameObject Effect_Destroyed;
    private float Att_time;
    // Use this for initialization
    void Start () {
        pAudio = GetComponent<AudioSource>();
        switch (this.tag)
        {
            case "EnemyA":
                Enemy_HP = 1;
                break;
            case "EnemyB":
                Enemy_HP = 3;
                break;
            case "Boss":
                Enemy_HP = 25;
                break;
        }
        _Player = GameObject.Find("Player");
        if (!this.CompareTag("Boss"))
        {
            Arrow_Position = GameObject.Find("ArrowPosition");
            obj = Instantiate(Arrow, Arrow_Position.transform.position, Arrow_Position.transform.rotation) as GameObject;
            obj.transform.parent = Arrow_Position.transform;
        }
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
            if(this.CompareTag("Boss"))
            {
                //pAudio.PlayOneShot(s_Cleared);
                GameObject.Find("Clear").GetComponent<RectTransform>().rotation = new Quaternion(0,0,0,0);
                Time.timeScale = 0;
            }
        }
        else
        {
            Att_time += Time.deltaTime;
            if (this.CompareTag("EnemyA") || this.CompareTag("EnemyB"))
            {
                if (Att_time > 4.0f)
                {
                    Handheld.Vibrate();
                    _Player.GetComponent<Player>().HP -= 1;
                    Att_time = 0;
                    Delete();
                }
                obj.transform.LookAt(this.transform);
                GetComponent<Rigidbody>().AddForce(this.transform.forward * 0.01f, ForceMode.VelocityChange);
            }
            
            transform.LookAt(_Player.transform);
            //transform.Translate(this.transform.localPosition * 0.005f);

        }
    }
    public void Delete()
    {
        GameObject eff = Instantiate(Effect_Destroyed, transform.position, Quaternion.identity) as GameObject;
        Destroy(eff, 2f);
        if (!this.CompareTag("Boss"))
        {
            GameObject.Find("GameRoot").GetComponent<GameRoot>().Spawn();
            pAudio.PlayOneShot(s_Destroyed);
            pAudio.volume = 10.0f;
            pAudio.spatialBlend = 0;
            Destroy(obj);
        }
        Destroy(this.gameObject);
    }
}
