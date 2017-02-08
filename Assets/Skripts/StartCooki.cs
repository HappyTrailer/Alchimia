using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class StartCooki : MonoBehaviour, IPointerClickHandler {

    public static int receptId = -1;

    public int Recept
    {
        set { receptId = value; }
        get { return receptId; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
