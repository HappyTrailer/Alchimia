using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CookyTool : MonoBehaviour, IDragHandler, /*IDropHandler,*/ IPointerDownHandler, IPointerUpHandler{

    static float R;
    static float G;
    static float B;
    public Text text;
    public GameObject circle;

    Vector3 startPos;

	void Start () {
        startPos = transform.position;
        R = 0;
        G = 0;
        B = 0;
	}

    void Update()
    {
        circle.GetComponent<Image>().color = new Color32(System.Convert.ToByte(R), System.Convert.ToByte(G), System.Convert.ToByte(B), 255);
        if(this.name == "R")
            text.text = R.ToString("F0");
        else if(this.name == "G")
            text.text = G.ToString("F0");
        else if (this.name == "B")
            text.text = B.ToString("F0");
    }

    public void OnDrag(PointerEventData eventData)
    {
        float x = 0;
        float y = 0;

        if (transform.position.x > eventData.position.x)
            x = transform.position.x - eventData.position.x;
        else
            x = eventData.position.x - transform.position.x;
        if (transform.position.y > eventData.position.y)
            y = transform.position.y - eventData.position.y;
        else
            y = eventData.position.y - transform.position.y;

        if (this.name == "R")
            R -= (x + y) / 100;
        else if (this.name == "G")
            G -= (x + y) / 100;
        else if (this.name == "B")
            B -= (x + y) / 100;

        if (R < 0)
            R = 255;
        else if (G < 0)
            G = 255;
        else if (B < 0)
            B = 255;

        transform.position = eventData.position;
    }

    /*public void OnDrop(PointerEventData eventData)
    {
        transform.position = startPos;
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = startPos;
    }
}
