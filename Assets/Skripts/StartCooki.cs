using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class StartCooki : MonoBehaviour, IPointerClickHandler {

    public static int globalReceptId = -1;
    public GameObject container;
    public GameObject itemPanel;
    public GameObject nameRecept;
    public GameObject sprite;
    public GameObject ingridients;

    int receptId = -1;
    GameObject item;

    public int Recept
    {
        set { receptId = value; }
        get { return receptId; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        globalReceptId = receptId;
        container.SetActive(true);
        for (int i = 0; i < itemPanel.transform.childCount; i++)
        {
            if (itemPanel.transform.GetChild(i).name != "Container")
                Destroy(itemPanel.transform.GetChild(i).gameObject);
        }

        sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListRecipePotion.masRecPotion[receptId].Sprite);
        nameRecept.GetComponent<Text>().text = ListRecipePotion.masRecPotion[receptId].NameRec;

        foreach (int id in ListRecipePotion.masRecPotion[receptId].Mass)
        {
            item = Instantiate(container);
            item.transform.parent = itemPanel.transform;
            item.transform.localScale = new Vector3(1, 1, 1);
            item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[id].Sprite);
            item.transform.GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[id].Name;
        }
        container.SetActive(false);
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
                    ingridients.transform.GetChild(pos - 1).GetChild(0).GetComponent<CookingIngridient>().Ingr = id;
                }
            } while(mass[i] != pos);
            if (i == 2)
                break;
            i++;
        }
    }
}
