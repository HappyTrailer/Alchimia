using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presintatoin : MonoBehaviour 
{
    public int count = 0;
    public GameObject[] objects;
    GameObject currentObj;

    void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
    }

	void Update () 
    {
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            switch(count)
            {
                case 0:
                    if (!objects[0].activeSelf)
                        DoCase(objects[0]);
                    break;
                case 1:
                    if (!objects[1].activeSelf)
                        DoCase(objects[1]);
                    break;
                case 2:
                    if (!objects[2].activeSelf)
                        DoCase(objects[2]);
                    break;
                case 3:
                    if (!objects[3].activeSelf)
                        DoCase(objects[3]);
                    break;
            }
        }
        if (currentObj != null)
            ShowObj(currentObj);
	}

    void DoCase(GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.localScale = new Vector3(0.01f, 0.01f);
        currentObj = obj;
        count++;
    }

    void ShowObj(GameObject obj)
    {
        obj.transform.localScale = Vector3.Lerp(obj.transform.localScale, new Vector3(1, 1), Time.deltaTime * 3);
    }
}
