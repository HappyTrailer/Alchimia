using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        if (ListRecipePotion.masRecPotion[receptId].Mass.Length == 2)
        {
            ingridients.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[ListRecipePotion.masRecPotion[receptId].Mass[0]].Sprite);
            ingridients.transform.GetChild(0).GetChild(0).name = ListIngredients.masIngredient[ListRecipePotion.masRecPotion[receptId].Mass[0]].Name;
            ingridients.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[ListRecipePotion.masRecPotion[receptId].Mass[1]].Sprite);
            ingridients.transform.GetChild(1).GetChild(0).name = ListIngredients.masIngredient[ListRecipePotion.masRecPotion[receptId].Mass[1]].Name;
        }
        else
        {
            int i = 0;
            while(true)
            {
                int pos = Random.Range(0, 3);
                if (ingridients.transform.GetChild(pos).GetChild(0).name == "Image")
                {
                    switch (pos)
                    {
                        case 0:
                            ingridients.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[ListRecipePotion.masRecPotion[receptId].Mass[i]].Sprite);
                            ingridients.transform.GetChild(0).GetChild(0).name = ListIngredients.masIngredient[ListRecipePotion.masRecPotion[receptId].Mass[i]].Name;
                            i++;
                            break;
                        case 1:
                            ingridients.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[ListRecipePotion.masRecPotion[receptId].Mass[i]].Sprite);
                            ingridients.transform.GetChild(1).GetChild(0).name = ListIngredients.masIngredient[ListRecipePotion.masRecPotion[receptId].Mass[i]].Name;
                            i++;
                            break;
                        case 2:
                            ingridients.transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[ListRecipePotion.masRecPotion[receptId].Mass[i]].Sprite);
                            ingridients.transform.GetChild(2).GetChild(0).name = ListIngredients.masIngredient[ListRecipePotion.masRecPotion[receptId].Mass[i]].Name;
                            i++;
                            break;
                    }
                }
                if(i == 3)
                {
                    break;
                }
            }
        }
    }
}
