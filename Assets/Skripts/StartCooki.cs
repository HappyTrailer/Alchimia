using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class StartCooki : MonoBehaviour, IPointerClickHandler
{
    public static int globalReceptId = -1;
    public GameObject containerHelp;
    public GameObject itemPanelHelp;
    public GameObject globalIngr;
    public static GameObject ingridients;
    public static GameObject globalItemPanelHelp;

    int receptId = -1;
    GameObject itemHelp;

    void Start()
    {
        globalItemPanelHelp = itemPanelHelp.transform.parent.parent.gameObject;
        ingridients = globalIngr;
    }

    public int Recept
    {
        set { receptId = value; }
        get { return receptId; }
    }

    public static bool LastIngridients()
    {
        int a = 0;
        for (int i = 0; i < ingridients.transform.childCount; i++)
        {
            if (ingridients.transform.GetChild(i).GetChild(0).gameObject.GetComponent<CookingIngridient>().enabled == true)
                a++;
        }
        if(a > 0)
            return false;
        return true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Interface.globalMenuItems.SetActive(false);
        Interface.globalCancelCooki.SetActive(true);
        Interface.globalPotion.SetActive(true);
        Interface.globalLojka.SetActive(true);
        itemPanelHelp.transform.parent.parent.gameObject.SetActive(true);
        globalReceptId = receptId;
        containerHelp.SetActive(true);
        for (int i = 0; i < itemPanelHelp.transform.childCount; i++)
        {
            if (itemPanelHelp.transform.GetChild(i).name != "Container")
                Destroy(itemPanelHelp.transform.GetChild(i).gameObject);
        }
        int count = 0;
        foreach (int id in ListRecipePotion.masRecPotion[receptId].Mass)
        {
            itemHelp = Instantiate(containerHelp);
            itemHelp.transform.SetParent(itemPanelHelp.transform);
            itemHelp.name = ListIngredients.masIngredient[id].Name;
            itemHelp.transform.localScale = new Vector3(1, 1, 1);
            itemHelp.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[id].Sprite);
            itemHelp.transform.GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[id].Name;
            count += ListIngredients.masIngredient[id].Red + ListIngredients.masIngredient[id].Green + ListIngredients.masIngredient[id].Blue;
        }
        Timer.averageValue = 1.0f / count;
        containerHelp.SetActive(false);
        IngridientsToCooki();
    }

    public void IngridientsToCooki()
    {
        int[] mass = new int[3];
        int i = 0;
        int pos = 0;
        foreach (int id in ListRecipePotion.masRecPotion[receptId].Mass)
        {
            do
            {
                pos = Random.Range(1, 4);
                if (!mass.Contains(pos))
                {
                    mass[i] = pos;
                    ingridients.transform.GetChild(pos - 1).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[id].Sprite);
                    ingridients.transform.GetChild(pos - 1).GetChild(0).gameObject.GetComponent<CookingIngridient>().enabled = true;
                    ingridients.transform.GetChild(pos - 1).GetChild(0).gameObject.GetComponent<CookingIngridient>().Ingr = id;
                    ingridients.transform.GetChild(pos - 1).GetChild(0).name = id.ToString();
                }
            } while (mass[i] != pos);
            if (i == 2)
                break;
            i++;
        }
        CookingIngridient.IngrMass = ListRecipePotion.masRecPotion[receptId].Mass;
        CookingIngridient.ItemPanelHelp = itemPanelHelp;
        Timer.SliderActivate();
        if(ListRecipePotion.masRecPotion[receptId].Mass.Length <= 3)
            CookingIngridient.NextIngrId = -1;
        else
            CookingIngridient.NextIngrId = 3;
    }

    public static void CancelCooki()
    {
        globalReceptId = -1;
        globalItemPanelHelp.SetActive(false);
        Interface.globalCancelCooki.SetActive(false);
        Interface.globalMenuItems.SetActive(true);
        Interface.globalPotion.SetActive(false);
        Interface.globalLojka.SetActive(false);
        for (int i = 0; i < ingridients.transform.childCount; i++)
        {
            ingridients.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/GameFiled/UIMask");
            ingridients.transform.GetChild(i).GetChild(0).gameObject.GetComponent<CookingIngridient>().enabled = false;
        }
        CookyTool.Reset();
        Timer.TimerStop();
        Timer.SliderDeActivate();
    }
}
