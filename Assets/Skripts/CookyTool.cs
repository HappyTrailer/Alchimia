using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CookyTool : MonoBehaviour, IDragHandler, /*IDropHandler,*/ IPointerDownHandler, IPointerUpHandler
{
    public static float R;
    public static float G;
    public static float B;
    public static float R2;
    public static float G2;
    public static float B2;
    public Text text;
    public GameObject circle;
    public bool vectorR;
    public bool vectorG;
    public bool vectorB;
    public float speedR;
    public float speedG;
    public float speedB;

    Vector3 startPos;

	void Start () {
        startPos = transform.position;
        Reset();
        speedR = 100;
        speedG = 100;
        speedB = 100;
	}

    void Update()
    {
        circle.GetComponent<Image>().color = new Color32(System.Convert.ToByte(R), System.Convert.ToByte(G), System.Convert.ToByte(B), 255);
        if (this.name == "R")
            text.text = R2.ToString("F0");
        else if (this.name == "G")
            text.text = G2.ToString("F0");
        else if (this.name == "B")
            text.text = B2.ToString("F0");
    }

    public static void ChangeRGB(int ingridientId)
    {
        R2 += ListIngredients.masIngredient[ingridientId].Red;
        G2 += ListIngredients.masIngredient[ingridientId].Green;
        B2 += ListIngredients.masIngredient[ingridientId].Blue;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Timer.flag)
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

            ChangeColor(x, y);

            transform.position = eventData.position;
        }
        else
            transform.position = startPos;
    }

    /*public void OnDrop(PointerEventData eventData)
    {
        transform.position = startPos;
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Timer.flag)
        {
            transform.position = eventData.position;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = startPos;
    }

    public static void Reset()
    {
        R2 = 0;
        G2 = 0;
        B2 = 0;
        R = 58;
        G = 190;
        B = 255;
    }

    public void ChangeVector(ref bool vector, ref float color, float x, float y, float speed)
    {
        if (vector)
        {
            color += (x + y) / speed;
            if (color >= 255)
            {
                vector = false;
                color = 255;
            }
        }
        else
        {
            color -= (x + y) / speed;
            if (color <= 0)
            {
                vector = true;
                color = 0;
            }
        }
    }

    public void ChangeColor(float x, float y)
    {
        if (this.name == "R")
        {
            R2 -= (x + y) / speedR;
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Fire"))
            {
                if (obj.transform.localScale.x < 1.5F)
                    obj.transform.localScale += new Vector3(0.01F, 0);
                if (obj.transform.localScale.y < 1.5F)
                    obj.transform.localScale += new Vector3(0, 0.01F);
            }
            if (R2 > 0)
                Timer.gradeValuePotion += ((x + y) / speedR) * Timer.averageValue;
        }
        else if (this.name == "G")
        {
            G2 -= (x + y) / speedG;
            if (G2 > 0)
                Timer.gradeValuePotion += ((x + y) / speedG) * Timer.averageValue;
        }
        else if (this.name == "B")
        {
            B2 -= (x + y) / speedB;
            if (B2 > 0)
                Timer.gradeValuePotion += ((x + y) / speedB) * Timer.averageValue;
        }

        if (R2 < 0)
            R2 = 0;
        else if (G2 < 0)
            G2 = 0;
        else if (B2 < 0)
            B2 = 0;

        if (this.name == "R" && R2 != 0)
            ChangeVector(ref vectorR, ref R, x, y, speedR);
        else if (this.name == "G" && G2 != 0)
            ChangeVector(ref vectorG, ref G, x, y, speedG);
        else if (this.name == "B" && B2 != 0)
            ChangeVector(ref vectorB, ref B, x, y, speedB);
    }
}
