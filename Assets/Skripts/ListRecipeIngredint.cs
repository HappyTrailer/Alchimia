using UnityEngine;
using System.Collections;

public class ListRecipeIngredint : MonoBehaviour {
    //Класс содержит в себе масив рецептов ингредиентов
    public static RecipeIngredint[] masRecIngr;

    void Start()
    {
        InitRec();
    }
    //Инициализация массива рецептов ингредиентов
    void InitRec()
    {
        masRecIngr = new RecipeIngredint[] {
            new RecipeIngredint(0, 0, 1, 3),
            new RecipeIngredint(8, 1, 2, 3),
            new RecipeIngredint(9, 1, 1, 3),
            new RecipeIngredint(1, 3, 1, 4),
            new RecipeIngredint(2, 2, 3, 5),
            new RecipeIngredint(3, 3, 4, 6),
            new RecipeIngredint(4, 2, 5, 7),
            new RecipeIngredint(5, 4, 6, 8),
            new RecipeIngredint(6, 5, 3, 9),
            new RecipeIngredint(7, 7, 8, 10)
        };
    }
}
