using UnityEngine;
using System.Collections;

public class UI_Function : MonoBehaviour {

    bool pause_Clicked;
	// Use this for initialization
	void Start () {
        pause_Clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
        Quit();
	}
    public void Quit()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
    public void Pause(GameObject _btn)
    {
        if(!pause_Clicked)
        {
            Time.timeScale = 0.0f;
            _btn.SetActive(false);
        }
        else
            _btn.SetActive(true);
    }
    public void Resume(GameObject _btn)
    {
        if (pause_Clicked)
        {
            Time.timeScale = 1;
            _btn.SetActive(true);
        }
        else
            _btn.SetActive(false);
    }
}
