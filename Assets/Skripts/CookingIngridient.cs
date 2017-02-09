using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CookingIngridient : MonoBehaviour, IPointerClickHandler 
{
    int ingridientId;

    public int Ingr
    {
        get { return ingridientId; }
        set { ingridientId = value; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
