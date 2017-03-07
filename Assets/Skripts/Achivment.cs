using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achivment
{
    string type;
    string name;
    int count;
    int money;
    bool done;
    string sprite;

    public Achivment(string type, string name, int count, int money, bool done, string sprite)
    {
        this.type = type;
        this.name = name;
        this.count = count;
        this.money = money;
        this.done = done;
        this.sprite = sprite;
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Count
    {
        get { return count; }
        set { count = value; }
    }

    public int Money
    {
        get { return money; }
        set { money = value; }
    }

    public string Sprite
    {
        get { return sprite; }
        set { sprite = value; }
    }

    public bool Done
    {
        get { return done; }
        set { done = value; }
    }
}
