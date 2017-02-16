using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TradeIngridients : MonoBehaviour
{
    public GameObject container;
    public GameObject itemsPanel;
    public GameObject money;
    public GameObject txt;

    GameObject item;
    int randomIngr;
    float timer;

    void Start()
    {
        timer = 600;
        FillShop();
	}

    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            FillShop();
            timer = 600;
        }
        txt.GetComponent<Text>().text = ((int)(timer / 60)).ToString("D2") + ":" + ((int)(timer % 60)).ToString("D2");
        money.GetComponent<Text>().text = Money.money.ToString();
    }

    public void FillShop()
    {
        container.SetActive(true);
        randomIngr = Random.Range(4, 10);
        for (int i = 0; i < itemsPanel.transform.childCount; i++)
        {
            if (itemsPanel.transform.GetChild(i).name != "Container")
                Destroy(itemsPanel.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < 3; i++)
        {
            int temp = i;
            item = Instantiate(container);
            item.transform.name = "Item";
            item.transform.parent = itemsPanel.transform;
            item.transform.localScale = new Vector3(1, 1, 1);
            item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[i].Sprite);
            item.transform.GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[i].Name;
            item.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => { BuyIngtidient(temp); });
        }
        int[] mass = new int[randomIngr];
        int id = 0;
        for (int i = 0; i < randomIngr; i++)
		{
            do
            {
                id = Random.Range(3, ListIngredients.masIngredient.Length);
                if (!mass.Contains(id))
                {
                    mass[i] = id;
                    int temp = id;
                    item = Instantiate(container);
                    item.transform.parent = itemsPanel.transform;
                    item.transform.localScale = new Vector3(1, 1, 1);
                    item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[id].Sprite);
                    item.transform.GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[id].Name;
                    item.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => { BuyIngtidient(temp); });
                }
            } while (mass[i] != id);
        }
        container.SetActive(false);
    }

    void BuyIngtidient(int id)
    {
        if (Money.money >= ListIngredients.masIngredient[id].Price)
        {
            bool flag = false;
            Money.money -= ListIngredients.masIngredient[id].Price;
            for (int i = 0; i < Inventory.listItem.Count; i++)
            {
                if (Inventory.listItem[i].Id == id)
                {
                    Inventory.listItem[i].Count++;
                    flag = true;
                    break;
                }
            }
            if (!flag)
                Inventory.listItem.Add(new ItemsInInventary(id, 1));
        }
    }
}
