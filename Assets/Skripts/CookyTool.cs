﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CookyTool : MonoBehaviour, IDragHandler, /*IDropHandler,*/ IPointerDownHandler, IPointerUpHandler{

    public Text text;
    public float number = 255;

    Vector3 startPos;

	void Start () {
        startPos = transform.position;
	}

    void Update()
    {
        text.text = number.ToString("F0");
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

        number -= (x + y) / 100;

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
