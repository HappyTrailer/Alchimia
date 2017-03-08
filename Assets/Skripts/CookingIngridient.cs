using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class CookingIngridient : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Vector2 startPos;
    int ingridientId;
    int ingridientOrder;
    static int[] ingridients;
    public static int nextIngrId;
    static GameObject itemPanelHelp;

    bool drag;

    void Start() 
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (drag)
            transform.position = Input.mousePosition;
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

    public static GameObject ItemPanelHelp
    {
        set { itemPanelHelp = value; }
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
        ListAchivments.ingridientUseCount++;
        ListAchivments.ChekAchiv();

        transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/GameFiled/UIMask");
        gameObject.GetComponent<CookingIngridient>().enabled = false;
        //======================================================================
        for (int i = 0; i < ingridients.Length; i++)
        {
            if (ingridients[i] != -1)
            {
                if (ingridients[i] != System.Convert.ToInt32(gameObject.name))
                {
                    Timer.countWrongIngridients++;
                } 
                break;
            }
        }
        //======================================================================
        for (int i = 0; i < ingridients.Length; i++)
        {
            if (ingridients[i] == ingridientId)
            {
                ingridients[i] = -1; 
                if (nextIngrId != -1)
                {
                    gameObject.name = ListIngredients.masIngredient[ingridients[nextIngrId]].Id.ToString();
                    GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[ingridients[nextIngrId]].Sprite);
                    GetComponent<CookingIngridient>().enabled = true;
                    GetComponent<CookingIngridient>().Ingr = ingridients[nextIngrId];
                    if (nextIngrId < ingridients.Length - 1)
                        nextIngrId++;
                    else
                        nextIngrId = -1;
                }
                itemPanelHelp.transform.GetChild(i + 1).gameObject.SetActive(false);
                break;
            }
        }
        //======================================================================
        for (int i = 0; i < Inventory.listItem.Count; i++)
        {
            if (Inventory.listItem[i].Id == ingridientId)
            {
                Inventory.listItem[i].Count--;
                break;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        drag = true;
        transform.GetComponent<Image>().raycastTarget = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "Kettle" || eventData.pointerCurrentRaycast.gameObject.name == "Potion"
            || eventData.pointerCurrentRaycast.gameObject.name == "Wood" || eventData.pointerCurrentRaycast.gameObject.name == "Fire")
        {
            UseIngridient();
        }
        drag = false;
        transform.GetComponent<Image>().raycastTarget = true;
        transform.position = startPos;
    }
}
