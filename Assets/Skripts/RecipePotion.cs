using UnityEngine;
using System.Collections;

public class RecipePotion : MonoBehaviour {

    int id;  //индентификатор
    int idPotion; //индентификатор производимого зелья
    int price;    // цена рецепта

    string nameRicipe; // Название рецепта

    int[] idIngredient; //Масив ингредиентов необходимых 
    //для производства зелья

    //Параметризированый конструктор для инициализации полей
    public RecipePotion(
                        int id,
                        int idPotion,
                        int price,
                        string nameRicipe,
                        int[] idIngredient
                        )
    {
        this.id = id;
        this.idPotion = idPotion;
        this.price = price;
        this.nameRicipe = nameRicipe;
        this.idIngredient = idIngredient;
    }
}
