using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static float timer;
    public static bool flag;
	
	void Update () 
    {
        if (flag)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
                flag = false;
            GetComponent<Text>().text = timer.ToString("F1");
        }
	}
}
