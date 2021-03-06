﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceptIngridientPanel : MonoBehaviour 
{
    public GameObject container;
    public GameObject itemsPanel;

    GameObject item;
    public static List<HelpReceptIngridient> listHRI;

    void Start()
    {
        listHRI = new List<HelpReceptIngridient>();
    }

    public void FillRecepts()
    {
        container.SetActive(true);
        for (int i = 0; i < itemsPanel.transform.childCount; i++)
        {
            if (itemsPanel.transform.GetChild(i).name != "Container")
                Destroy(itemsPanel.transform.GetChild(i).gameObject);
        }
        OpenIngridients();
        if (listHRI != null)
        {
            for (int i = 0; i < listHRI.Count; i++)
            {
                item = Instantiate(container);
                item.transform.name = "Item";
                item.transform.SetParent(itemsPanel.transform);
                item.transform.localScale = new Vector3(1, 1, 1);
                item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[listHRI[i].Ingr].Sprite);
                item.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = ListIngredients.masIngredient[listHRI[i].Ingr].Red.ToString();
                item.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[listHRI[i].Ingr].Green.ToString();
                item.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = ListIngredients.masIngredient[listHRI[i].Ingr].Blue.ToString();
                if (!listHRI[i].R1)
                    item.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = ListIngredients.masIngredient[ListRecipeIngredint.masRecIngr[listHRI[i].Recept].IdResultIngredient].Red.ToString();
                if (!listHRI[i].G1)
                    item.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[ListRecipeIngredint.masRecIngr[listHRI[i].Recept].IdResultIngredient].Green.ToString();
                if (!listHRI[i].B1)
                    item.transform.GetChild(4).GetChild(2).GetComponent<Text>().text = ListIngredients.masIngredient[ListRecipeIngredint.masRecIngr[listHRI[i].Recept].IdResultIngredient].Blue.ToString();
            }
        }
        container.SetActive(false);
    }

    public void OpenIngridients()
    {
        RecipeIngredint buff;
        for (int i = 0; i < ListIngredients.masIngredient.Length; i++)
        {
            if (ListIngredients.masIngredient[i].Opened)
            {
                for (int k = 0; k < ListRecipeIngredint.masRecIngr.Length; k++)
                {
                    if(ListRecipeIngredint.masRecIngr[k].IdResultIngredient == ListIngredients.masIngredient[i].Id)
                    {
                        int reults = ListRecipeIngredint.masRecIngr[k].IdResultIngredient;
                        int first = ListRecipeIngredint.masRecIngr[k].IdFirstIngredient;
                        int second = ListRecipeIngredint.masRecIngr[k].IdSecondInredient;
                        buff = ListRecipeIngredint.masRecIngr[k];
                        item = Instantiate(container);
                        item.transform.name = "Item";
                        item.transform.SetParent(itemsPanel.transform);
                        item.transform.localScale = new Vector3(1, 1, 1);
                        item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[buff.IdFirstIngredient].Sprite);
                        item.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = ListIngredients.masIngredient[buff.IdFirstIngredient].Red.ToString();
                        item.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[buff.IdFirstIngredient].Green.ToString();
                        item.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = ListIngredients.masIngredient[buff.IdFirstIngredient].Blue.ToString();
                        item.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[buff.IdSecondInredient].Sprite);
                        item.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ListIngredients.masIngredient[buff.IdSecondInredient].Red.ToString();
                        item.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[buff.IdSecondInredient].Green.ToString();
                        item.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = ListIngredients.masIngredient[buff.IdSecondInredient].Blue.ToString();
                        item.transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>(ListIngredients.masIngredient[buff.IdResultIngredient].Sprite);
                        item.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = ListIngredients.masIngredient[buff.IdResultIngredient].Red.ToString();
                        item.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = ListIngredients.masIngredient[buff.IdResultIngredient].Green.ToString();
                        item.transform.GetChild(4).GetChild(2).GetComponent<Text>().text = ListIngredients.masIngredient[buff.IdResultIngredient].Blue.ToString();
                        item.AddComponent<Button>().onClick.AddListener(() => { CraftIngr(reults, first, second); });
                        break;
                    }
                }
            }
        }
    }

    public bool ChekIngrCount(int first, int second)
    {
        bool f = false;
        bool s = false;
        for (int i = 0; i < Inventory.listItem.Count; i++)
        {
            if (Inventory.listItem[i].Id == first)
                f = true;
            if (Inventory.listItem[i].Id == second)
                s = true;
        }
        if(f && s)
            return true;
        return false;
    }

    public void CraftIngr(int reults, int first, int second)
    {
        if (ChekIngrCount(first, second))
        {
            bool flag = false;
            for (int i = 0; i < Inventory.listItem.Count; i++)
            {
                if (Inventory.listItem[i].Id == reults)
                {
                    Inventory.listItem[i].Count++;
                    flag = true;
                    break;
                }
            }
            if (!flag)
                Inventory.listItem.Add(new ItemsInInventary(reults, 1));
            for (int i = 0; i < Inventory.listItem.Count; i++)
            {
                if (Inventory.listItem[i].Id == first)
                    Inventory.listItem[i].Count -= 1;
                if (Inventory.listItem[i].Id == second)
                    Inventory.listItem[i].Count -= 1;
            }
        }
    }
}
