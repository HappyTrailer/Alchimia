using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ListRecipePotion : MonoBehaviour {
    //Класс содержит массив всех рецептов

    public GameObject receptPanel;
    public GameObject container;
    GameObject item;
    public static RecipePotion[] masRecPotion;
	// Use this for initialization
	void Start () {
        InitMasRecPotion();
        FillRecepts(1);
    }
    //Инициализация массива рецептов
    void InitMasRecPotion()
    {
        masRecPotion = new RecipePotion[] {
            new RecipePotion(0, 0, 10, "Чай", new int[] {0, 1}, true, "Sprite/Ing/Oreh", 1),
            new RecipePotion(1, 1, 15, "Лечебный бальзам", new int[] {0, 1, 2}, true, "Sprite/Ing/Poganki", 1),
            new RecipePotion(2, 2, 20, "Вытяжка из подорожника", new int[] {2, 2, 2}, true, "Sprite/Ing/Ejevika", 1),
            new RecipePotion(3, 3, 25, "Мыло", new int[] {3, 2, 1}, false, "Sprite/Ing/Hmel", 2),
            new RecipePotion(4, 4, 30, "Настойка боярышника", new int[] {3, 4, 0}, false, "Sprite/Ing/Kropiva", 2),
            new RecipePotion(5, 5, 35, "Сироп из ежевики", new int[] {6, 3, 3}, false, "Sprite/Ing/Byzina", 3),
            new RecipePotion(5, 5, 35, "Золотая стружка", new int[] {10, 10, 9}, false, "Sprite/Ing/Gold", 4)
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

        foreach (RecipePotion i in masRecPotion)
        {
            if (grade == i.Grade)
            {
                item = Instantiate(container);
                item.transform.parent = receptPanel.transform;
                item.transform.localScale = new Vector3(1, 1, 1);
                item.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(i.Sprite);
                item.transform.GetChild(1).GetComponent<Text>().text = i.NameRec;
                item.transform.GetChild(2).GetComponent<Text>().text = "Цена: " + i.Price;
                item.transform.name = i.Id.ToString();
            }
        }
        container.SetActive(false);
    }
}
