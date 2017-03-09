using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TradeTools : MonoBehaviour 
{
    public GameObject container;
    public GameObject itemsPanel;
    public GameObject money;

    GameObject item;

    void Start()
    {
        FillShop();
    }

    void Update()
    {
        money.GetComponent<Text>().text = Money.money.ToString();
    }

    public void FillShop()
    {
        container.SetActive(true);
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
            item.transform.SetParent(itemsPanel.transform);
            item.transform.localScale = new Vector3(1, 1, 1);
            //item.transform.GetChild(0).GetComponent<Image>().sprite = 
            //item.transform.GetChild(1).GetComponent<Text>().text = 
            item.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => { BuyTool(temp); });
        }
        container.SetActive(false);
    }

    void BuyTool(int id)
    {
        
    }
}
