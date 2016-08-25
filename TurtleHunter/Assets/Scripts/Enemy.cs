using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public enum State{ MOVE, NONE, DESTROY };
    State Enemy_State;
    public bool b_isExist;
    private GameObject Arrow_Position;
    public GameObject Arrow;
    private GameObject _Player;
    private GameObject obj;
    // Use this for initialization
    void Start () {
        _Player = GameObject.Find("Player");
        Arrow_Position = GameObject.Find("ArrowPosition");
        obj = Instantiate(Arrow, Arrow_Position.transform.position, Arrow_Position.transform.rotation) as GameObject;
        obj.transform.parent = Arrow_Position.transform;
    }
	// Update is called once per frame
	void Update () {
        transform.LookAt(_Player.transform);
        obj.transform.LookAt(this.transform);
        if (!gameObject.GetComponent<MeshRenderer>().isVisible)
        {
            Debug.Log("invisible!");
            //나중에 이부분에 화살표도 안보이도록 설정할것!
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
            Destroy(obj);
    }
}
