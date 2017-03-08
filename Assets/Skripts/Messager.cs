using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messager : MonoBehaviour 
{
    public GameObject panel;
    const float timeDuration = 3;
    float timer = 0;
    static List<Message> mess;
    bool showNotif;

    void Start()
    {
        mess = new List<Message>();
    }

    void Update()
    {
        if(mess.Count > 0 || showNotif)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                panel.SetActive(false);
                showNotif = false;
                if(mess.Count > 0)
                    DoNotif();
            }
        }
    }

    void DoNotif()
    {
        panel.SetActive(true);
        panel.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(mess[0].Sprite);
        panel.transform.GetChild(1).GetComponent<Text>().text = mess[0].FirstText;
        panel.transform.GetChild(2).GetComponent<Text>().text = mess[0].SecondText;
        mess.RemoveAt(0);
        timer = timeDuration;
        showNotif = true;
    }

    public static void AddMess(string sprite, string firstText, string secondText)
    {
        mess.Add(new Message(sprite, firstText, secondText));
    }
}

class Message
{
    string sprite;
    string firstText;
    string secondText;

    public Message(string sprite, string firstText, string secondText)
    {
        this.sprite = sprite;
        this.firstText = firstText;
        this.secondText = secondText;
    }

    public string SecondText
    {
        get { return secondText; }
        set { secondText = value; }
    }

    public string FirstText
    {
        get { return firstText; }
        set { firstText = value; }
    }

    public string Sprite
    {
        get { return sprite; }
        set { sprite = value; }
    }
}
