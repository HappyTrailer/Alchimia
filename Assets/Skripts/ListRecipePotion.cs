﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ListRecipePotion : MonoBehaviour 
{
    //Класс содержит массив всех рецептов

    public GameObject receptPanel;
    public GameObject container;
    GameObject item;
    public static RecipePotion[] masRecPotion;
	// Use this for initialization
	void Start () 
    {
        InitMasRecPotion();
        FillRecepts(1);
    }
    //Инициализация массива рецептов
    void InitMasRecPotion()
    {
        masRecPotion = new RecipePotion[] {
            new RecipePotion(0, 10, "Чай", new int[] {0, 1}, "Sprite/Ing/Oreh", 1),
            new RecipePotion(1, 15, "Лечебный бальзам", new int[] {0, 1, 2}, "Sprite/Ing/Poganki", 1),
            new RecipePotion(2, 35, "Тест рецепт", new int[] {0, 1, 2, 0, 1, 2, 0, 1, 2, 0}, "Sprite/Ing/Malahit", 1),
            new RecipePotion(3, 20, "Вытяжка из подорожника", new int[] {2, 2, 2}, "Sprite/Ing/Ejevika", 1),
            new RecipePotion(4, 25, "Мыло", new int[] {3, 2, 1}, "Sprite/Ing/Hmel", 2),
            new RecipePotion(5, 30, "Настойка боярышника", new int[] {3, 4, 0}, "Sprite/Ing/Kropiva", 2),
            new RecipePotion(6, 35, "Сироп из ежевики", new int[] {6, 3, 3}, "Sprite/Ing/Byzina", 3),
            new RecipePotion(7, 35, "Золотая стружка", new int[] {10, 10, 9}, "Sprite/Ing/Gold", 4)
        };
    }

    public void FillRecepts(int grade)
    {
        container.SetActive(true);
        for (int i = 0; i < receptPanel.transform.childCount; i++)
        {
            if (receptPanel.transform.GetChild(i).name != "Container")
                Destroy(receptPanel.transform.GetChild(i).gameObject);
        }
        int k = 0;
        foreach (RecipePotion i in masRecPotion)
        {
            if (grade == i.Grade)
            {
                item = Instantiate(container);
                item.transform.SetParent(receptPanel.transform);
                item.transform.localScale = new Vector3(1, 1, 1);
                item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(i.Sprite);
                item.transform.GetChild(1).GetComponent<Text>().text = i.NameRec;
                item.transform.GetChild(2).GetComponent<Text>().text = i.Price.ToString();
                item.transform.name = i.Id.ToString();
                k++;
            }
            if (k == 6)
                break;
        }
        container.SetActive(false);
    }
}
