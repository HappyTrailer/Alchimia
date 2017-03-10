using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public int page;
    public int nextItem;
    public static List<ItemsInInventary> listItem;
    GameObject itemsPanel;

	void Start () 
    {
        page = 1;
        listItem = new List<ItemsInInventary>();
        listItem.Add(new ItemsInInventary(0, 10));
        listItem.Add(new ItemsInInventary(1, 50));
        listItem.Add(new ItemsInInventary(2, 20));
        itemsPanel = this.transform.GetChild(1).gameObject;
	}

    void Update()
    {
        for (int i = 0; i < Inventory.listItem.Count; i++)
        {
            if (listItem[i].Count <= 0)
                listItem.RemoveAt(i);
        }
    }

    public void FillInventory()
    {
        nextItem = (page * 9) - 9;
        for (int i = 0; i < 9; i++)
        {
            itemsPanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/GameFiled/UIMask");
            itemsPanel.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = "";
            itemsPanel.transform.GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();
            itemsPanel.transform.GetChild(i).GetComponent<Button>().enabled = false;
        }
        for (int i = 0; i < 9; i++)
        {
            if (i < listItem.Count)
            {
                int temp = listItem[nextItem + i].Id;//===================BUG
                itemsPanel.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[listItem[nextItem + i].Id].Sprite);
                itemsPanel.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = listItem[nextItem + i].Count.ToString();
                itemsPanel.transform.GetChild(i).GetComponent<Button>().enabled = true;
                itemsPanel.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(() => { SellItem(temp); });
            }
        }
    }

    void SellItem(int id)
    {
        Money.money += ListIngredients.masIngredient[id].Price / 4;
        ListAchivments.moneyGetCount += ListIngredients.masIngredient[id].Price;
        ListAchivments.ChekAchiv();
        for (int i = 0; i < Inventory.listItem.Count; i++)
        {
            if (listItem[i].Id == id)
            {
                listItem[i].Count--;
                if (listItem[i].Count > 1)
                    itemsPanel.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = listItem[i].Count.ToString();
                else
                    FillInventory();
                break;
            }
        }
    }

    public void NextPage()
    {
        page++;
        if (listItem.Count >= (page * 9) - 9)
            FillInventory();
        else
            page--;
    }

    public void PrevPage()
    {
        if(page > 1)
            page--;
        FillInventory();
    }
}
