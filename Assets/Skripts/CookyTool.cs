using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CookyTool : MonoBehaviour, IDragHandler, /*IDropHandler,*/ IPointerDownHandler, IPointerUpHandler{

    Vector3 startPos;

	void Start () {
        startPos = transform.position;
	}

    public void OnDrag(PointerEventData eventData)
    {
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
