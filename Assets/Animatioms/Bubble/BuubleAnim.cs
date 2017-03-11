using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuubleAnim : MonoBehaviour {

    public GameObject bubbleSystem;
    public GameObject container;
    List<GameObject> bubbles;

    GameObject newBubble;
    float w;
    float h;
    public float constCount = 0.2f;
    public float count;
    int step = 1;

    void Start()
    {
        count = constCount;
        bubbles = new List<GameObject>();
        w = bubbleSystem.GetComponent<RectTransform>().rect.width / 2;
        h = bubbleSystem.GetComponent<RectTransform>().rect.height / 2;
    }

	void Update () 
    {
        if (bubbles.Count < 100)
        {
            if (count <= 0)
            {
                newBubble = Instantiate(container);
                newBubble.transform.SetParent(bubbleSystem.transform);
                newBubble.GetComponent<Image>().color = new Color32(System.Convert.ToByte(CookyTool.R), System.Convert.ToByte(CookyTool.G), System.Convert.ToByte(CookyTool.B), 255);
                newBubble.SetActive(true);
                float s = Random.Range(0.5f, 2);
                newBubble.transform.localScale = new Vector3(s, s);
                float x = Random.Range(-w, w);
                float y = Random.Range(-h, h);
                newBubble.transform.localPosition = new Vector3(x, y);
                bubbles.Add(newBubble);
                count = constCount;
            }
            else
            {
                count -= Time.deltaTime;
            }
        }
        for (int i = 0; i < bubbles.Count; i++)
        {
            bubbles[i].transform.position = Vector3.Lerp(bubbles[i].transform.position, new Vector3(bubbles[i].transform.position.x, bubbles[i].transform.position.y + 10), Time.deltaTime);
            Color32 c = bubbles[i].GetComponent<Image>().color;
            if (c.a <= 1)
            {
                Destroy(bubbles[i]);
                bubbles.RemoveAt(i);
            }
            else
            {
                if (step <= 0)
                {
                    byte a = System.Convert.ToByte(c.a - 1);
                    bubbles[i].GetComponent<Image>().color = new Color32(System.Convert.ToByte(CookyTool.R), System.Convert.ToByte(CookyTool.G), System.Convert.ToByte(CookyTool.B), a);
                    step = 1;
                }
                else
                    step -= 1;
            }
        }
	}
}
