using UnityEngine;
using System.Collections;

public class RecipePotion : MonoBehaviour {

    int id;  //индентификатор
    int idPotion; //индентификатор производимого зелья
    int price;    // цена рецепта

    string nameRicipe; // Название рецепта
    string sprite;

    bool open;
    int[] idIngredient; //Масив ингредиентов необходимых 
    //для производства зелья

    //Параметризированый конструктор для инициализации полей
    public RecipePotion(
                        int id,
                        int idPotion,
                        int price,
                        string nameRicipe,
                        int[] idIngredient,
                        bool open,
                        string sprite
                        )
    {
        this.id = id;
        this.idPotion = idPotion;
        this.price = price;
        this.nameRicipe = nameRicipe;
        this.idIngredient = idIngredient;
        this.open = open;
        this.sprite = sprite;
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
}
