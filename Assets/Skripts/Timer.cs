using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static float timer;
    public static bool flag;
    public static GameObject obj;

    void Start()
    {
        obj = gameObject;
        gameObject.SetActive(false);
    }
	
	void Update () 
    {
        if (flag)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                gameObject.SetActive(false);
                flag = false;
            }
            GetComponent<Text>().text = timer.ToString("F1");
        }
	}
}
