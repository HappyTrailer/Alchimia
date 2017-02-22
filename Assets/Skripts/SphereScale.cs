using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScale : MonoBehaviour 
{
    public GameObject red;
    public GameObject green;
    public GameObject blue;

    void Update()
    {
        red.transform.localScale = Vector3.Lerp(red.transform.localScale, new Vector3(1 + CookyTool.R2 / 1000, 1 + CookyTool.R2 / 1000, 0), Time.deltaTime);
        green.transform.localScale = Vector3.Lerp(green.transform.localScale, new Vector3(1 + CookyTool.G2 / 1000, 1 + CookyTool.G2 / 1000, 0), Time.deltaTime);
        blue.transform.localScale = Vector3.Lerp(blue.transform.localScale, new Vector3(1 + CookyTool.B2 / 1000, 1 + CookyTool.B2 / 1000, 0), Time.deltaTime);
    }
}
