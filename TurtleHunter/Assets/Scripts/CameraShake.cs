using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    public float ShakeTime = 0f;
    // Use this for initialization
    public bool isDestroyed;
	void Start () {
        isDestroyed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDestroyed)
            Shake();
	}
    void Shake()
    {
        ShakeTime += Time.deltaTime;
        if (ShakeTime < 1.0f)
        {
            this.transform.localPosition = Random.insideUnitSphere * 0.5f;
        }
        else
        {
            ShakeTime = 0f;
            transform.position = Vector3.zero;
            isDestroyed = false;
        }
        
    }
}
