﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivmentPanel : MonoBehaviour 
{
    public GameObject itemPanel;
    public GameObject container;

    GameObject item;

    void Start()
    {
        ListAchivments.AchivmentsMasStart();
        container.SetActive(true);
        for (int i = 0; i < ListAchivments.masAchivments.Length; i++)
        {
            item = Instantiate(container);
            item.transform.SetParent(itemPanel.transform);
            item.transform.localScale = new Vector3(1, 1, 1);
        }
        container.SetActive(false);
    }

    public void ShowAchivments()
    {
        for (int i = 0; i < ListAchivments.masAchivments.Length; i++)
        {
            Achivment ach = ListAchivments.masAchivments[i];
            item = itemPanel.transform.GetChild(i + 1).gameObject;
            item.name = ach.Name;
            item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ach.Sprite);
            item.transform.GetChild(1).GetComponent<Text>().text = ach.Name;
            float count = 0;
            switch (ach.Type)
            {
                case "moneyGet":
                    count = ListAchivments.moneyGetCount;
                    break;
                case "moneySet":
                    count = ListAchivments.moneySetCount;
                    break;
                case "potionCooki":
                    count = ListAchivments.potionCookiCount;
                    break;
                case "ingridientOpen":
                    count = ListAchivments.ingridientOpenCount;
                    break;
                case "ingridientUse":
                    count = ListAchivments.ingridientUseCount;
                    break;
                case "ingridientBuy":
                    count = ListAchivments.ingridientBuyCount;
                    break;
            }
            if (count >= ach.Count)
            {
                count = ach.Count;
                item.transform.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
            }
            item.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = count + " из " + ach.Count;
            item.transform.GetChild(2).GetComponent<Image>().fillAmount = ((count * 100) / ach.Count) / 100;
        }
    }
}
