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

    GameObject item;

    public void OnPointerClick(PointerEventData eventData)
    {
        container.SetActive(true);
        for (int i = 0; i < itemPanel.transform.childCount; i++)
        {
            if (itemPanel.transform.GetChild(i).name != "Container")
                Destroy(itemPanel.transform.GetChild(i).gameObject);
        }
        int idRecept = System.Convert.ToInt32(this.name);

        sprite.GetComponent<Image>().sprite = Resources.Load<Sprite>(ListRecipePotion.masRecPotion[idRecept].Sprite);
        nameRecept.GetComponent<Text>().text = ListRecipePotion.masRecPotion[idRecept].NameRec;

        foreach (int id in ListRecipePotion.masRecPotion[idRecept].Mass)
        {
            item = Instantiate(container);
            item.transform.parent = itemPanel.transform;
            item.transform.localScale = new Vector3(1, 1, 1);
            item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[id].Sprite);
            item.transform.GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[id].Name;
        }
        CheckIngrInInventory(ListRecipePotion.masRecPotion[idRecept].Mass);

        buttonStart.GetComponent<StartCooki>().Recept = idRecept;

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
                        Debug.Log(buff[i].Id + " in recept = " + buff[i].Count + " enaf in inventory = " + item.Count);
                        buff[i].EnafFlag = true;
                    }
                    else if (buff[i].Id == item.Id && buff[i].Count > item.Count)
                    {
                        Debug.Log(buff[i].Id + " in recept = " + buff[i].Count + "not enaf in inventory = " + item.Count);
                        buff[i].EnafFlag = false;
                    }
                }
                if (!buff[i].EnafFlag)
                {
                    Debug.Log(buff[i].Id + " in recept = " + buff[i].Count + " —- in inventory = 0");
                }
            }
            else
                Debug.Log(i + " - null");
        }
    }
}
