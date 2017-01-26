using UnityEngine;
using System.Collections;

public class ListRecipeIngredint : MonoBehaviour {
    //Класс содержит в себе масив рецептов ингредиентов
    RecipeIngredint[] masRecIngr;

    void Start()
    {
        InitRec();
    }
    //Инициализация массива рецептов ингредиентов
    void InitRec()
    {
        masRecIngr = new RecipeIngredint[] {
            new RecipeIngredint(1,1,1,1)
        };
    }
}
