using UnityEngine;
using System.Collections;

public class ItemsInInventary {

    int id;
    int count;

    public ItemsInInventary(int id, int count)
    {
        this.id = id;
        this.count = count;
    }

    public int Id
    {
        get { return id; }
    }

    public int Count
    {
        get { return count; }
    }
}
