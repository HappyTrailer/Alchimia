using UnityEngine;
using System.Collections;

public class RecipePotion 
{
    int id;  //индентификатор
    int price;    // цена рецепта

    string nameRicipe; // Название рецепта
    string sprite;

    int grade;
    int[] idIngredient; //Масив ингредиентов необходимых 
    //для производства зелья

    //Параметризированый конструктор для инициализации полей
    public RecipePotion(
                        int id,
                        int price,
                        string nameRicipe,
                        int[] idIngredient,
                        string sprite,
                        int grade
                        )
    {
        this.id = id;
        this.price = price;
        this.nameRicipe = nameRicipe;
        this.idIngredient = idIngredient;
        this.sprite = sprite;
        this.grade = grade;
    }

    public string Sprite
    { 
        get { return sprite; } 
    }

    public string NameRec
    {
        get { return nameRicipe; }
    }

    public int Price
    {
        get { return price; }
    }

    public int Id
    {
        get { return id; }
    }

    public int[] Mass
    {
        get { return idIngredient; }
    }

    public int Grade
    {
        get { return grade; }
    }
}
