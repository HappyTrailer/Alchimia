using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class CookingIngridient : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    Vector2 startPos;
    int ingridientId;
    int ingridientOrder;
    static int[] ingridients;
    public static int nextIngrId;
    static GameObject itemPanel;

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

    public static GameObject ItemPanel
    {
        set { itemPanel = value; }
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

    public int Order
    {
        get { return ingridientOrder; }
        set { ingridientOrder = value; }
    }

    public void UseIngridient()
    {
        CookyTool.ChangeRGB(ingridientId);
        Timer.TimerStart();

        transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/GameFiled/UIMask");
        gameObject.GetComponent<CookingIngridient>().enabled = false;

        for (int i = 0; i < ingridients.Length; i++)
        {
            if (ingridients[i] != -1)
            {
                if (ingridients[i] != System.Convert.ToInt32(gameObject.name))
                {
                    Timer.countWrongIngridients++;
                    Debug.Log(Timer.countWrongIngridients);
                } 
                break;
            }
        }

        for (int i = 0; i < ingridients.Length; i++)
        {
            if (ingridients[i] == ingridientId)
            {
                if (nextIngrId != -1)
                {
                    ingridients[i] = -1; 
                    gameObject.name = ListIngredients.masIngredient[ingridients[nextIngrId]].Id.ToString();
                    GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[ingridients[nextIngrId]].Sprite);
                    GetComponent<CookingIngridient>().enabled = true;
                    GetComponent<CookingIngridient>().Ingr = ingridients[nextIngrId];
                    if (nextIngrId < ingridients.Length - 1)
                        nextIngrId++;
                    else
                        nextIngrId = -1;
                }
                itemPanel.transform.GetChild(i + 1).gameObject.SetActive(false);
                break;
            }
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
