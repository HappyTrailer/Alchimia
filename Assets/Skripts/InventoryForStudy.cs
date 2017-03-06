using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryForStudy : MonoBehaviour
{
    public GameObject scrollerIngridientCount;
    public GameObject itemPanel;
    public GameObject container;

    GameObject item;
    GameObject canvas;
    int currentGrade;

    void Update()
    {
        canvas = GameObject.Find("Canvas");
        scrollerIngridientCount.transform.GetChild(5).GetComponent<Text>().text = scrollerIngridientCount.transform.GetChild(2).GetComponent<Slider>().value.ToString();
    }

    public void ShowIngridient(int grade)
    {
        currentGrade = grade;
        container.SetActive(true);
        for (int i = 0; i < itemPanel.transform.childCount; i++)
        {
            if (itemPanel.transform.GetChild(i).name != "Container")
                Destroy(itemPanel.transform.GetChild(i).gameObject);
        }
        foreach (ItemsInInventary ingr in Inventory.listItem)
        {
            if (ListIngredients.masIngredient[ingr.Id].Grade == grade)
            {
                int temp = ingr.Id;
                item = Instantiate(container);
                item.name = ingr.Id.ToString();
                item.transform.parent = itemPanel.transform;
                item.transform.localScale = new Vector3(1, 1, 1);
                item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[ingr.Id].Sprite);
                item.transform.GetChild(1).GetComponent<Text>().text = "R" + ListIngredients.masIngredient[ingr.Id].Red.ToString();
                item.transform.GetChild(2).GetComponent<Text>().text = "G" + ListIngredients.masIngredient[ingr.Id].Green.ToString();
                item.transform.GetChild(3).GetComponent<Text>().text = "B" + ListIngredients.masIngredient[ingr.Id].Blue.ToString();
                item.transform.GetChild(4).GetComponent<Text>().text = ingr.Count.ToString();
                item.transform.GetComponent<Button>().onClick.AddListener(() => { ShowScrollerIngridientCount(temp); });
            }
        }
        container.SetActive(false);
    }

    public void ShowScrollerIngridientCount(int id)
    {
        scrollerIngridientCount.transform.GetChild(3).GetComponent<Button>().onClick.RemoveAllListeners();
        foreach(ItemsInInventary item in Inventory.listItem)
        {
            if (item.Id == id)
            {
                int buffId = item.Id;
                scrollerIngridientCount.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[item.Id].Sprite);
                scrollerIngridientCount.transform.GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[item.Id].Name;
                if (ResearchTools.tool == "Blender")
                {
                    scrollerIngridientCount.transform.GetChild(2).GetComponent<Slider>().maxValue = 1;
                    scrollerIngridientCount.transform.GetChild(2).GetComponent<Slider>().value = 1;
                    scrollerIngridientCount.transform.GetChild(2).GetComponent<Slider>().enabled = false;
                }
                else
                {
                    scrollerIngridientCount.transform.GetChild(2).GetComponent<Slider>().enabled = true;
                    scrollerIngridientCount.transform.GetChild(2).GetComponent<Slider>().minValue = 1;
                    if (item.Count > ResearchTools.maxCountIngridientInMortar)
                        scrollerIngridientCount.transform.GetChild(2).GetComponent<Slider>().maxValue = ResearchTools.maxCountIngridientInMortar;
                    else
                        scrollerIngridientCount.transform.GetChild(2).GetComponent<Slider>().maxValue = item.Count;

                }
                scrollerIngridientCount.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => { IngridientsToTools(buffId); });
            }
        }
    }

    public void IngridientsToTools(int id)
    {
        float count = scrollerIngridientCount.transform.GetChild(2).GetComponent<Slider>().value;
        for (int i = 0; i < Inventory.listItem.Count; i++)
        {
            if (Inventory.listItem[i].Id == id)
            {
                Inventory.listItem[i].Count -= (int)count;
                break;
            }
        }
        if (ResearchTools.tool == "Blender")
        {
            if(ResearchTools.currentIngridient == null)
            {
                ResearchTools.currentIngridient = new ItemsInInventary(id, (int)count);
                canvas.GetComponent<Interface>().ShowScrollerIngridientCount(1);
                ShowIngridient(currentGrade);
            }
            else
            {
                ResearchTools.currentIngridientSecond = new ItemsInInventary(id, (int)count);
                canvas.GetComponent<Interface>().ShowScrollerIngridientCount(2);
            }
        }
        else
        {
            ResearchTools.currentIngridient = new ItemsInInventary(id, (int)count);
            ResearchTools.currentIngridientSecond = null;
            canvas.GetComponent<Interface>().ShowScrollerIngridientCount(2);
        }
    }
}
