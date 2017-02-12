using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickOnRecept : MonoBehaviour, IPointerClickHandler
{
    public GameObject container;
    public GameObject itemPanel;
    public GameObject nameRecept;
    public GameObject sprite;
    public GameObject buttonStart;
    int idRecept;
    GameObject item;

    public void OnPointerClick(PointerEventData eventData)
    {
        idRecept = System.Convert.ToInt32(this.name);

        container.SetActive(true);
        for (int i = 0; i < itemPanel.transform.childCount; i++)
        {
            if (itemPanel.transform.GetChild(i).name != "Container")
                Destroy(itemPanel.transform.GetChild(i).gameObject);
        }

        sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListRecipePotion.masRecPotion[idRecept].Sprite);
        nameRecept.GetComponent<Text>().text = ListRecipePotion.masRecPotion[idRecept].NameRec;

        foreach (int id in ListRecipePotion.masRecPotion[idRecept].Mass)
        {
            item = Instantiate(container);
            item.name = ListIngredients.masIngredient[id].Id.ToString();
            item.transform.parent = itemPanel.transform;
            item.transform.localScale = new Vector3(1, 1, 1);
            item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[id].Sprite);
            item.transform.GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[id].Name;
        }
        buttonStart.GetComponent<StartCooki>().Recept = idRecept;
        buttonStart.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        CheckIngrInInventory(ListRecipePotion.masRecPotion[idRecept].Mass);

        container.SetActive(false);
    }

    void CheckIngrInInventory(int[] mass1)
    {
        int index = 0;
        int count = 0;
        ItemsInInventary[] buff = new ItemsInInventary[mass1.Length];
        int[] mass = new int[mass1.Length];
        for (int i = 0; i < mass1.Length; i++)
        {
            mass[i] = mass1[i];
        }
        //============================================
        for (int i = 0; i < mass.Length; i++)
        {
            if (mass[i] != -1)
            {
                count++;
                for (int j = i + 1; j < mass.Length; j++)
                {
                    if (mass[i] == mass[j])
                    {
                        count++;
                        mass[j] = -1;
                    }
                }
                buff[index] = new ItemsInInventary(mass[i], count);
                index++;
                count = 0;
            }
        }
        for (int i = 0; i < mass.Length; i++)
        {
            if (buff[i] != null)
            {
                foreach (var item in Inventory.listItem)
                {
                    if (buff[i].Id == item.Id && buff[i].Count <= item.Count)
                    {
                        buff[i].EnafFlag = true;
                    }
                    else if (buff[i].Id == item.Id && buff[i].Count > item.Count)
                    {
                        buff[i].EnafFlag = false;
                    }
                }
                if (!buff[i].EnafFlag)
                {
                    buff[i].EnafFlag = false;
                }
            }
        }
        for (int i = 0; i < itemPanel.transform.childCount; i++)
        {
            for (int j = 0; j < buff.Length; j++)
                if (buff[j] != null)
                {
                    if (itemPanel.transform.GetChild(i).name == buff[j].Id.ToString() && !buff[j].EnafFlag)
                    {
                        itemPanel.transform.GetChild(i).transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/GameFiled/red cross");
                        buttonStart.GetComponent<StartCooki>().enabled = false;
                        buttonStart.GetComponent<Button>().enabled = false;
                        buttonStart.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                    }
                }
                else
                    break;
        }

    }
}
