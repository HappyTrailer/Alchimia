using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpReceptIngridient
{
    int idRecept;
    int idIngr;
    bool R;
    bool G;
    bool B;

    public HelpReceptIngridient(int idRecept, int idIngr, bool R, bool G, bool B)
    {
        this.idRecept = idRecept;
        this.idIngr = idIngr;
        this.R = R;
        this.G = G;
        this.B = B;
    }
    public int Recept
    {
        get { return idRecept; }
        set { idRecept = value; }
    }
    public int Ingr
    {
        get { return idIngr; }
        set { idIngr = value; }
    }
    public bool R1
    {
        get { return R; }
        set { R = value; }
    }
    public bool G1
    {
        get { return G; }
        set { G = value; }
    }
    public bool B1
    {
        get { return B; }
        set { B = value; }
    }
}
