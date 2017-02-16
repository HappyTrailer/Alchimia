using UnityEngine;
using System.Collections;

public class ItemsInInventary {

    int id;
    int count; 
    bool enafFlag;

    public ItemsInInventary(int id, int count)
    {
        this.id = id;
        this.count = count;
        this.enafFlag = false;
    }

    public int Id
    {
        get { return id; }
    }

    public int Count
    {
        get { return count; }
        set { count = value; }
    }

    public bool EnafFlag
    {
        get { return enafFlag; }
        set { enafFlag = value; }
    }
}
