using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class CookingIngridient : MonoBehaviour, IDragHandler, /*IDropHandler,*/ IPointerDownHandler, IPointerUpHandler
{
    Vector2 startPos;
    int ingridientId;
    static int[] ingridients;
    static int nextIngrId; 

    void Start() 
    {
        startPos = transform.position;
    }

    public static int[] IngrMass
    {
        set 
        {
            ingridients = new int[value.Length];
            for(int i = 0; i < value.Length; i++)
            {
                ingridients[i] = value[i];
            }
        }
    }

    public static int NextIngrId
    {
        set
        {
            nextIngrId = value;
        }
    }

    public int Ingr
    {
        get { return ingridientId; }
        set { ingridientId = value; }
    }

    public void UseIngridient()
    {
        CookyTool.R += ListIngredients.masIngredient[ingridientId].Red;
        CookyTool.G += ListIngredients.masIngredient[ingridientId].Green;
        CookyTool.B += ListIngredients.masIngredient[ingridientId].Blue;

        Timer.flag = true;
        Timer.timer = 10;

        transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/GameFiled/UIMask");
        gameObject.GetComponent<CookingIngridient>().enabled = false;
        if (nextIngrId != -1)
        {
            for (int i = 0; i < ingridients.Length; i++)
            {
                if (ingridients[i] == ingridientId)
                {
                    ingridients[i] = -1;
                    GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[ingridients[nextIngrId]].Sprite);
                    GetComponent<CookingIngridient>().enabled = true;
                    GetComponent<CookingIngridient>().Ingr = ingridients[nextIngrId];
                    break;
                }
            }
            if (nextIngrId < ingridients.Length - 1)
                nextIngrId++;
            else
                nextIngrId = -1;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(0).position));
        Vector2 test = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(test, (Input.mousePosition));
        if (hit.collider && hit.collider.name == "Kettle")
        {
            UseIngridient(); 
        }
        transform.position = startPos;
    }
}
